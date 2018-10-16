using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutAppDomain.DataModel
{
    public class CheckoutAppContext :DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<CheckedoutProduct> checkedoutProducts { get; set; }
        public DbSet<InvoiceDetails> invoiceDetails { get; set; }
    }
}
