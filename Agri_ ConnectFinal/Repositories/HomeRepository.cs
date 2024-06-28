using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agri__ConnectFinal.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Vegetable>> Vegetables()
        {
            return await _db.Vegetables.ToListAsync();
        }

        public async Task<IEnumerable<Grocery>> GetGroceries(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            var groceriesQuery = from grocery in _db.Groceries
                                 join vegetable in _db.Vegetables
                                 on grocery.VegetableId equals vegetable.Id
                                 where string.IsNullOrEmpty(sTerm) || grocery.GroceryName.ToLower().StartsWith(sTerm)
                                 select new Grocery
                                 {
                                     Id = grocery.Id,
                                     Image = grocery.Image,
                                     SellerName = grocery.SellerName,
                                     VegetableId = grocery.VegetableId,
                                     VegetableName = vegetable.VegetableName, // Fetch the specific product type
                                     Price = grocery.Price
                                 };

            if (categoryId > 0)
            {
                groceriesQuery = groceriesQuery.Where(a => a.VegetableId == categoryId);
            }

            return await groceriesQuery.ToListAsync();
        }
    }
}
