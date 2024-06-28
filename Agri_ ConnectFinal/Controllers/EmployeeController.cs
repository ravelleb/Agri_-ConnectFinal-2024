using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agri__ConnectFinal.Repositories;
using Agri__ConnectFinal.Models.DTOs; // Add this namespace
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agri__ConnectFinal.Areas.Employee.Controllers
{
    [Area("Employee")]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly StockRepository _stockRepository;

        public EmployeeController(StockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            IEnumerable<StockDisplayModel> stocks = await _stockRepository.GetStocks(searchString);
            return View(stocks);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var stock = await _stockRepository.GetStockByGroceryId(id);
            if (stock == null)
            {
                return NotFound();
            }
            var stockDTO = new StockDTO { GroceryId = stock.GroceryId, Quantity = stock.Quantity };
            return View(stockDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroceryId, Quantity")] StockDTO stockDTO)
        {
            if (id != stockDTO.GroceryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _stockRepository.ManageStock(stockDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StockExists(stockDTO.GroceryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stockDTO);
        }

        private async Task<bool> StockExists(int id)
        {
            return await _stockRepository.GetStockByGroceryId(id) != null;
        }
    }
}
