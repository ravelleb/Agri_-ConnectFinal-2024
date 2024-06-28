using System.ComponentModel.DataAnnotations;

namespace Agri__ConnectFinal.Models.DTOs
{
    public class StockDTO
    {
        public int GroceryId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a non-negative value.")]
        public int Quantity { get; set; }
    }
}