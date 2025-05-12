using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeStats.Interface
{
    public interface ITradeStatsService
    {
        public void ProcessTradebook(string fullExcelPath, int sheetPosition, int rowsToSkip);

        public void PrintAllTrades(string? symbol = null, string? segment = null, DateTime startDate = default, DateTime endDate = default);

        public void SaveAllTrades(string targetFilePath);
    }
}
