namespace TradeStats.Models
{
    public class Position
    {
        public string Symbol { get; set; }

        public int Quantity { get; set; } = 0;

        public int RemainingQuantity { get; set; } = 0;

        public double AverageEntryPrice { get; set; } = 0;

        public double AverageExitPrice { get; set; } = 0;

        public DateTime FirstEntryTradeDate { get; set; }

        public DateTime LastExitTradeDate { get; set; }

        public bool IsLong { get; set; }

        public Position(string symbol, int quantity, double averagePrice, bool isLong, DateTime firstEntryDate)
        {
            Symbol = symbol;
            Quantity = quantity;
            AverageEntryPrice = averagePrice;
            IsLong = isLong;
            FirstEntryTradeDate = firstEntryDate;
        }
    }
}
