namespace Agri__ConnectFinal.Models
{
    public class GroceryDisplayModel
    {
        public IEnumerable<Grocery> Groceries { get; set; }
        public IEnumerable<Vegetable> Vegetables { get; set; }
        public string STerm { get; set; } = "";
        public int CategoryId { get; set; } = 0;
    }
}
