using ClosedXML.Excel;
using TradeStats.Models;

namespace TradeStats.Helpers
{
    public static class ExcelSheetHelper
    {
        public static List<TradebookEntity> GetTradebookEntitiesFromExcel(string fullExcelPath, int sheetPosition, int rowsToSkip)
        {
            var tradebookEntities = new List<TradebookEntity>();
            // Logic to read from Excel file and populate tradebookEntities
            // This is a placeholder for the actual implementation
            var workbook = new XLWorkbook(fullExcelPath);
            var worksheet = workbook.Worksheet(sheetPosition);

            foreach (var row in worksheet.RangeUsed().RowsUsed().Skip(rowsToSkip)) // Skip header
            {
                var dateStr = row.Cell(3).GetString();
                var executionTimeStr = row.Cell(13).GetString();
                var tradebookEntity = new TradebookEntity
                {
                    Symbol = row.Cell(1).GetString(),
                    TradeType = row.Cell(7).GetString(),
                    Quantity = row.Cell(9).GetValue<int>(),
                    Price = row.Cell(10).GetValue<double>(),
                    TradeDate = DateTime.Parse(dateStr),
                    Segment = row.Cell(5).GetString(),
                    OrderExecutionTime = DateTime.Parse(executionTimeStr),
                };
                tradebookEntities.Add(tradebookEntity);
            }

            return tradebookEntities;
        }
    }
}
