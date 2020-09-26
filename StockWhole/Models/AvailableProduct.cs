using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockWhole.Models
{
    [Table ("AvailableProduct")]
    public class AvailableProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the Item Name")]
        [StringLength(50)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Enter the Quantity")]

        public int Quantity { get; set; }
    }
}
