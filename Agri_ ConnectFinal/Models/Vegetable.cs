﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agri__ConnectFinal.Models
{
    [Table("Vegetable")]
    public class Vegetable
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string VegetableName { get; set; }
        [Required]
        [MaxLength(40)]
        public string ProductType { get; set; } // Add this property
        public List<Grocery> Groceries { get; set; }
    }
}
