using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agri__ConnectFinal.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Grocery>> GetGroceries(string sTerm = "", int categoryId = 0);
        Task<IEnumerable<Vegetable>> Vegetables();
    }
}
