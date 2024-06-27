using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri__ConnectFinal.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public int GroceryId { get; set; }
        public int Quantity  { get; set; }
        public double UnitPrice { get; set; }
        public Order Order { get; set; }
        public Grocery Grocery { get; set; }
    }
}
