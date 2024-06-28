using Agri__ConnectFinal.Models.DTOs; // Add this namespace

namespace Agri__ConnectFinal.Repositories
{
    public interface IStockRepository1
    {
        Task<IEnumerable<StockDisplayModel>> GetStocks(string sTerm = "");
        Task<Stock?> GetStockByGroceryId(int groceryId);
        Task ManageStock(StockDTO stockToManage);
    }
}
