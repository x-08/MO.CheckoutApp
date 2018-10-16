using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAppDomain.Classes
{
    public class InvoiceDetails
    {
        [Key]
        public int Id { get; set; }
        public double Price { get; set; }

        [Required]
        public ICollection<CheckedoutProduct> MyProperty { get; set; }
        public DateTime Time { get; set; }
    }
}
