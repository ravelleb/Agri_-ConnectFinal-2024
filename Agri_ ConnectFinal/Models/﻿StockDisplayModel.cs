using System.ComponentModel.DataAnnotations;

namespace Agri__ConnectFinal.Models.DTOs
{
    public class StockDisplayModel
    {
        [Required]
        public int GroceryId { get; set; }

        [Required]
        [StringLength(100)]
        public string GroceryName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
