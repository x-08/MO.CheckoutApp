using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutApp.Service.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
        Product SearchProduct(Guid code);
        IQueryable<Product> ListProducts();

    }
}
