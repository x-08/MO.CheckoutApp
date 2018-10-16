using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CheckoutAppDomain.Classes
{
    public class CheckedoutProduct
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        [Required]
        public Product Product { get; set; }
        public double Price { get; set; }
    }
}
