using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockWhole.Models
{
   [Table ("NeededStock")]
    public class NeededStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the Seller Name")]
        [StringLength(50)]
        public string SellerName { get; set; }

        [Required(ErrorMessage = "Enter the Stock & Quantity")]

        public string StockQuantity { get; set; }
    }
}
