namespace Agri__ConnectFinal.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int groceryId, int qty);
        Task<int> RemoveItem(int groceryId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
    }
}
