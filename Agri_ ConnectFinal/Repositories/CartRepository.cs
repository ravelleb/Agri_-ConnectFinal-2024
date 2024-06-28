using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Agri__ConnectFinal.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepository(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> AddItem(int groceryId, int qty)
        {
            string userId = GetUserId();
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("User is not logged-in");

                var cart = await GetCart(userId);
                if (cart is null)
                {
                    cart = new ShoppingCart
                    {
                        UserId = userId
                    };
                    _db.ShoppingCarts.Add(cart);
                }
                await _db.SaveChangesAsync();

                var cartItem = await _db.CartDetails
                                        .FirstOrDefaultAsync(a => a.ShoppingCart_Id == cart.Id && a.GroceryId == groceryId);
                if (cartItem is not null)
                {
                    cartItem.Quantity += qty;
                }
                else
                {
                    cartItem = new CartDetail
                    {
                        GroceryId = groceryId,
                        ShoppingCart_Id = cart.Id,
                        Quantity = qty
                    };
                    _db.CartDetails.Add(cartItem);
                }
                await _db.SaveChangesAsync();
                await transaction.CommitAsync();

                var cartItemCount = await GetCartItemCount(userId);
                return cartItemCount;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw; // Re-throw the exception to be handled by higher-level logic if necessary
            }
        }

        public async Task<int> RemoveItem(int groceryId)
        {
            string userId = GetUserId();
            try
            {
                if (string.IsNullOrEmpty(userId))
                    throw new Exception("User is not logged-in");

                var cart = await GetCart(userId);
                if (cart is null)
                    throw new Exception("Invalid Cart");

                var cartItem = await _db.CartDetails.FirstOrDefaultAsync(a => a.ShoppingCart_Id == cart.Id && a.GroceryId == groceryId);
                if (cartItem is null)
                    throw new Exception("No items in cart");

                if (cartItem.Quantity == 1)
                {
                    _db.CartDetails.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity -= 1;
                }

                await _db.SaveChangesAsync();

                var cartItemCount = await GetCartItemCount(userId);
                return cartItemCount;
            }
            catch (Exception ex)
            {
                throw; // Re-throw the exception to be handled by higher-level logic 
            }
        }

        public async Task<ShoppingCart> GetUserCart()
        {
            var userId = GetUserId();
            if (userId == null)
                throw new Exception("Invalid UserId");

            var shoppingCart = await _db.ShoppingCarts
                .Include(a => a.CartDetails)
                .ThenInclude(a => a.Grocery)
                .ThenInclude(a => a.Vegetable)
                .FirstOrDefaultAsync(a => a.UserId == userId);
            return shoppingCart;
        }

        public async Task<int> GetCartItemCount(string userId = "")
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = GetUserId();
            }

            var data = await (from cart in _db.ShoppingCarts
                              join cartDetail in _db.CartDetails
                              on cart.Id equals cartDetail.ShoppingCart_Id
                              where cart.UserId == userId
                              select new { cartDetail.Id }
                             ).ToListAsync();
            return data.Count;
        }

        public async Task<ShoppingCart> GetCart(string userId)
        {
            var cart = await _db.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId);
            return cart;
        }

        private string GetUserId()
        {
            var principal = _httpContextAccessor.HttpContext.User;
            string userId = _userManager.GetUserId(principal);
            return userId;
        }
    }
}
