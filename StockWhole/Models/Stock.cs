using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockWhole.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Date in dd/mm/yyyy")]
        [StringLength(10)]
        public string Date { get; set; }

        [Required(ErrorMessage = "Enter the Seller Name")]
        [StringLength(50)]
        public string SellerName { get; set; }

        [Required(ErrorMessage = "Enter the Seller Phone")]
        
        public string SellerPhone { get; set; }

        [Required(ErrorMessage = "Enter the Seller Address")]
        [StringLength(100)]
        public string SellerAddress { get; set; }

        [Required(ErrorMessage = "Enter the Stock and Quantity")]

        public string StockQuantity { get; set; }

        [Required(ErrorMessage = "Enter the Total Amount of Stock")]
        [StringLength(10)]
        public string Amount { get; set; }
    }
}
