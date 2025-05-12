using Microsoft.Extensions.Logging;
using TradeStats.Helpers;
using TradeStats.Interface;
using TradeStats.Models;

namespace TradeStats.Service
{
    public class TradeStatsService(ILogger<TradeStatsService> logger) : ITradeStatsService
    {
        private readonly ILogger<TradeStatsService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private List<TradebookEntity> _tradebookEntities = [];
        private List<Position> _trades = [];

        /*
         * 1. Loads the data from excel into memory
         * 2. Processes the trades out of the tradebook
         * 
         *  It matches all the sell orders with buy orders and print the trades based on order execution time
         *  It assumes that the orders in the excel sheet was in increasing order of the execution time
         *  
         *  TODO: Add filteration logic based on parameters
         */
        public void ProcessTradebook(string fullExcelPath, int sheetPosition, int rowsToSkip)
        {
            try
            {
                _logger.LogInformation("Processing tradebook from {FullExcelPath} at sheet position {SheetPosition}", fullExcelPath, sheetPosition);
                _tradebookEntities = ExcelSheetHelper.GetTradebookEntitiesFromExcel(fullExcelPath, sheetPosition, rowsToSkip);

                _logger.LogInformation("Processing {TradebookEntitiesCount} tradebook entities", _tradebookEntities.Count);
                var uniqueSymbols = GetUniqueSymbols();
                var positions = new Dictionary<string, Position>();
                foreach (var uniqueSymbol in uniqueSymbols)
                {
                    foreach (var item in _tradebookEntities)
                    {
                        if (item.Symbol == uniqueSymbol)
                        {
                            if (!positions.ContainsKey(uniqueSymbol))
                            {
                                positions.Add(uniqueSymbol, new Position(uniqueSymbol, 0, 0, item.TradeType.Contains("buy"), item.TradeDate));
                            }
                            
                            var position = positions[uniqueSymbol];
                            if (IsAddOrder(item, position))
                            {
                                position.Quantity += item.Quantity;
                                position.AverageEntryPrice = ((position.AverageEntryPrice * position.RemainingQuantity) + (item.Price * item.Quantity)) / (position.RemainingQuantity + item.Quantity);
                                position.RemainingQuantity += item.Quantity;
                            }
                            else
                            {
                                var quantitySold = position.Quantity - position.RemainingQuantity;
                                position.AverageExitPrice = ((position.AverageExitPrice * quantitySold) + (item.Price * item.Quantity)) / (quantitySold + item.Quantity);
                                position.RemainingQuantity -= item.Quantity;
                            }

                            if (position.RemainingQuantity == 0)
                            {
                                position.LastExitTradeDate = item.TradeDate;
                                _trades.Add(position);
                                positions.Remove(uniqueSymbol);
                            }
                        }
                    }
                }
                _logger.LogInformation("Tradebook processed and trades derived\n");

                _trades.Sort((x, y) => x.FirstEntryTradeDate.CompareTo(y.FirstEntryTradeDate));
                _trades.Sort((x, y) => x.LastExitTradeDate.CompareTo(y.LastExitTradeDate));

                _logger.LogInformation("Trades sorted by entry and then exit dates\n");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing tradebook");
            }
        }

        public void PrintAllTrades(string? symbol, string? segment, DateTime startDate, DateTime endDate)
        {
            _logger.LogInformation("Printing all trades...");
            _logger.LogInformation("Total trades: {TotalTrades}", _trades.Count);

            Console.WriteLine($"{"Symbol",-20}{"Qty",6}{"Entry",10}{"Exit",10}{"IsLong",8}{"EntryDate",20}{"ExitDate",20}");
            Console.WriteLine(new string('-', 100));

            foreach (var pos in _trades)
            {
                Console.WriteLine(
                    $"{pos.Symbol,-20}" +
                    $"{pos.Quantity,6}" +
                    $"{pos.AverageEntryPrice,10:F2}" +
                    $"{pos.AverageExitPrice,10:F2}" +
                    $"{(pos.IsLong ? "Long" : "Short"),8}" +
                    $"{pos.FirstEntryTradeDate,20:yyyy-MM-dd}" +
                    $"{pos.LastExitTradeDate,20:yyyy-MM-dd}"
                );
            }
        }

        private List<string> GetUniqueSymbols()
        {
            return _tradebookEntities.Select(x => x.Symbol).Distinct().ToList();
        }

        private static bool IsAddOrder(TradebookEntity tradebookEntity, Position position)
        {
            if (position.IsLong && tradebookEntity.TradeType.Contains("sell"))
            {
                return false;
            }
            if (!position.IsLong && tradebookEntity.TradeType.Contains("buy"))
            {
                return false;
            }
            return true;
        }

        public void SaveAllTrades(string targetFilePath)
        {
            throw new NotImplementedException();
        }
    }
}
