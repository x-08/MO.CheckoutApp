using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutAppDomain.DataModel.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(CheckoutAppContext context) : base(context)
        {
        }

        public CheckoutAppContext CheckoutAppContext
        {
            get { return Context as CheckoutAppContext; }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return CheckoutAppContext.products.ToList();
        }


 
    }
}
