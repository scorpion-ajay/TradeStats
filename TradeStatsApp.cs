using System.Text.RegularExpressions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TradeStats.Interface;

public class TradeStatsApp : BackgroundService
{
    private readonly ILogger<TradeStatsApp> _logger;
    private readonly ITradeStatsService _service;

    public TradeStatsApp(ILogger<TradeStatsApp> logger, ITradeStatsService tradeStatsService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _service = tradeStatsService ?? throw new ArgumentNullException(nameof(tradeStatsService));
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("TradeStatsApp starting");

        while (!cancellationToken.IsCancellationRequested)
        {
            Console.Write("> ");
            var input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            var parts = Regex.Matches(input, @"[\""].+?[\""]|\S+")
                 .Select(m => m.Value.Trim('"'))
                 .ToArray();
            var command = parts[0].ToLower();
            var args = parts.Skip(1).ToArray();

            switch (command)
            {
                case "process":
                    if (args.Length == 0)
                    {
                        Console.WriteLine("Please provide the full path to the Excel file (in double quotes), SheetPosition in the workbook and count of top rows to skip !!");
                        break;
                    }
                    var filePath = args[0];
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"File not found: {filePath}");
                        break;
                    }
                    if (!int.TryParse(args[^2], out int sheetIndex))
                    {
                        Console.WriteLine("Invalid sheet index.");
                        break;
                    }
                    if (!int.TryParse(args[^1], out int rowsToSkip))
                    {
                        Console.WriteLine("Invalid rowsToSkip value.");
                        break;
                    }
                    _service.ProcessTradebook(filePath, sheetIndex, rowsToSkip);
                    break;

                case "print":
                    _service.PrintAllTrades();
                    break;

                case "save":
                    _service.SaveAllTrades("test");
                    break;

                case "help":
                    Console.WriteLine("Available commands:\n  process <full excel path in double quotes> <sheet Index in excel workbook> <count of top rows to skip>  - Load and process Excel\n  print  - Print all trades\n  save  - Save all trades in a target file\n  exit   - Exit the app \n\n");
                    break;

                case "exit":
                    _logger.LogInformation("Shutting down...");
                    return;

                default:
                    Console.WriteLine("Unknown command. Type 'help' to see available commands.");
                    break;
            }

            await Task.Delay(10); // Slight pause between inputs
        }
    }
}
