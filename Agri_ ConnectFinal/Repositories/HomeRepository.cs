using Microsoft.EntityFrameworkCore;

namespace Agri__ConnectFinal.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Grocery>> GetGroceries(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Grocery> groceries = await (from grocery in _db.Groceries
                                                    join vegetable in _db.Vegetables
                                                    on grocery.VegetableId equals vegetable.Id
                                                    where string.IsNullOrWhiteSpace(sTerm) || (grocery != null && grocery.SellerName.ToLower().StartsWith(sTerm))
                                                    select new Grocery
                                                    {
                                                        Id = grocery.Id,
                                                        Image = grocery.Image,
                                                        SellerName = grocery.SellerName,
                                                        VegetableId = grocery.VegetableId,
                                                        VegetableName = vegetable.VegetableName,
                                                    }).ToListAsync();

            if (categoryId > 0)
            {
                groceries = groceries.Where(a => a.VegetableId == categoryId).ToList();
            }

            return groceries;
        }
    }
}
