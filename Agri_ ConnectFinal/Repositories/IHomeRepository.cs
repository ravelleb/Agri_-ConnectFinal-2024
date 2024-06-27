namespace Agri__ConnectFinal
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Grocery>> GetGroceries(string sTerm = "", int categoryId = 0);
    }
}