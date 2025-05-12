using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using TradeStats.Interface;
using TradeStats.Service;

public class Program
{
    public static async Task Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();

        try
        {
            var host = Host.CreateDefaultBuilder(args)
                .UseSerilog() // Plug Serilog into generic host
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<ITradeStatsService, TradeStatsService>();
                    services.AddHostedService<TradeStatsApp>();
                })
                .Build();

            await host.RunAsync();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "App terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
        Console.WriteLine("Hello, World from Main!");
    }
}
