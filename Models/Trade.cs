namespace TradeStats.Models
{
    public class Trade
    {
        public required string Symbol { get; set; }

        public double AverageEntryPrice { get; set; }

        public double AverageExitPrice { get; set; }

        public int TotalQuantity { get; set; }

        public DateTime FirstEntryTradeDate { get; set; }

        public DateTime LastExitTradeDate { get; set; }

        public double TotalVolume()
        {
            return TotalQuantity * AverageEntryPrice;
        }
    }
}
