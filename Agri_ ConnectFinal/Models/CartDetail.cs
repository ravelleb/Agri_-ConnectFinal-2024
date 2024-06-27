using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri__ConnectFinal.Models
{
    [Table("CartDetail")]
    public class CartDetail
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCart_Id { get; set; }
        [Required]
        public int GroceryId { get; set; }
        public int Quantity { get; set; }
        public Grocery Grocery { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
