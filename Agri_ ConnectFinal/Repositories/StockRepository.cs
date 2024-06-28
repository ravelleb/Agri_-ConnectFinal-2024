using Microsoft.EntityFrameworkCore;
using Agri__ConnectFinal.Models;
using Agri__ConnectFinal.Models.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agri__ConnectFinal.Repositories
{
    public class StockRepository : IStockRepository1
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock?> GetStockByGroceryId(int groceryId) => await _context.Stocks.FirstOrDefaultAsync(s => s.GroceryId == groceryId);

        public async Task ManageStock(StockDTO stockToManage)
        {
            var existingStock = await GetStockByGroceryId(stockToManage.GroceryId);
            if (existingStock is null)
            {
                var stock = new Stock { GroceryId = stockToManage.GroceryId, Quantity = stockToManage.Quantity };
                _context.Stocks.Add(stock);
            }
            else
            {
                existingStock.Quantity = stockToManage.Quantity;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "")
        {
            var stocks = await (from grocery in _context.Groceries
                                join stock in _context.Stocks
                                on grocery.Id equals stock.GroceryId
                                into grocery_stock
                                from groceryStock in grocery_stock.DefaultIfEmpty()
                                where string.IsNullOrWhiteSpace(sTerm) || grocery.GroceryName.Contains(sTerm, StringComparison.OrdinalIgnoreCase)
                                select new StockDisplayModel
                                {
                                    GroceryId = grocery.Id,
                                    GroceryName = grocery.GroceryName,
                                    Quantity = groceryStock == null ? 0 : groceryStock.Quantity
                                }).ToListAsync();
            return stocks;
        }
    }
}
