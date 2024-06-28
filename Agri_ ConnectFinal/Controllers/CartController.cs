using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Agri__ConnectFinal.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepo;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartRepository cartRepo, ILogger<CartController> logger)
        {
            _cartRepo = cartRepo;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(int groceryId, int qty = 1, int redirect = 0)
        {
            try
            {
                var cartCount = await _cartRepo.AddItem(groceryId, qty);
                if (redirect == 0)
                    return Json(new { success = true, cartCount }); // Ensure it returns JSON

                return RedirectToAction("GetUserCart");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding item to cart.");
                return Json(new { success = false, message = ex.Message }); // Return JSON error response
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int groceryId)
        {
            try
            {
                var cartCount = await _cartRepo.RemoveItem(groceryId);
                return RedirectToAction("GetUserCart");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing item from cart.");
                return Json(new { success = false, message = ex.Message }); // Return JSON error response
            }
        }

        public async Task<IActionResult> GetUserCart()
        {
            var cart = await _cartRepo.GetUserCart();
            return View(cart);
        }

        [HttpGet]
        public async Task<IActionResult> GetTotalItemInCart()
        {
            try
            {
                int cartItem = await _cartRepo.GetCartItemCount();
                return Json(new { success = true, cartItem }); // Ensure it returns JSON
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total items in cart.");
                return Json(new { success = false, message = ex.Message }); // Return JSON error response
            }
        }
    }
}
