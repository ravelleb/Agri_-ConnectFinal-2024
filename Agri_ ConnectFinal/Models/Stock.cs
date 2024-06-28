using System.ComponentModel.DataAnnotations.Schema;

namespace Agri__ConnectFinal.Models
{
    [Table ("Stock")]
    public class Stock
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int GroceryId { get; set; }  // Foreign key property
        public Grocery Grocery { get; set; }  // Navigation property for the one-to-one relationship
    }

}
