using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StockWhole.Models
{
    [Table("Shopkeeper")]
    public class Shopkeeper
    {
        int Amount;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the Item Name")]
        [StringLength(50)]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Enter the Quantity")]
        
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Enter the Price")]
        
        public int Price { get; set; }

        public int amount
        {
            get { return Amount; }
            set
            {
                if (value == 0)
                {
                    Amount = Price * Quantity;
                }
                else
                {
                    Amount = value;
                }
            }
        }


        [Required(ErrorMessage = "Enter Date in dd/mm/yyyy")]
        [StringLength(10)]
        public string Date { get; set; }
   
    }
}
