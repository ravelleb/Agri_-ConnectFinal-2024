using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agri__ConnectFinal.Models
{
    [Table("Farmer")]
    public class Farmer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Grocery> Groceries { get; set; }
    }
}
