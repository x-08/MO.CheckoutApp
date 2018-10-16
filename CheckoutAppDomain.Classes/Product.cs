using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes.Enumerations;

namespace CheckoutAppDomain.Classes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Code { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
    }
}
