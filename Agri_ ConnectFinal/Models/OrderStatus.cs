using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri__ConnectFinal.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public int Id { get; set; }
        [Required]
        public int statusId { get; set; }
        [Required]
        [MaxLength(20)]
        public string? StatusName { get; set; }
    }
}
