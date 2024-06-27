using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri__ConnectFinal.Models;

[Table("Grocery")]
public class Grocery
{
    public int Id { get; set; }
    [Required]
    [MaxLength(40)]
    public string? GroceryName { get; set; }
    [Required]
    [MaxLength(40)]
    public string? SellerName { get; set; }
    public double Price { get; set; }
    public string? Image { get; set; }
    [Required]
    public int VegetableId { get; set; }
    public Vegetable Vegetable { get; set; }
    public List<OrderDetail> OrderDetail { get; set; }
    public List<CartDetail> CartDetail { get; set; }

    [NotMapped]
    public string VegetableName { get; set; }
}
