namespace TradeStats.Models
{
    public class TradebookEntity
    {
        public required string Symbol { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public DateTime TradeDate { get; set; }

        public required string TradeType { get; set; } // e.g., "Buy", "Sell"

        public required string Segment { get; set; } // ex: EQ

        public DateTime OrderExecutionTime { get; set; }

        public double GetTradeValue()
        {
            return Price * Quantity;
        }
    }
}
