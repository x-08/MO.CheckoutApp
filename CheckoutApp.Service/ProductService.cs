using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutApp.Service.Interfaces;
using CheckoutAppDomain.Classes;
using CheckoutAppDomain.DataModel.Repository;

namespace CheckoutApp.Service
{
    public class ProductService : IProductService
    {
        IUnitOfWork worker;

        public ProductService(IUnitOfWork worker)
        {
            this.worker = worker;
        }

        public void AddProduct(Product product)
        {
            var code = product.Code;
            var p = SearchProduct(code);
            if(p == null)
            {
                worker.Products.Add(product);
                worker.Complete();
            }
            else
            {
                throw new ArgumentException("Product already exists");
            }
     
        }


        public IQueryable<Product> ListProducts()
        {
            return worker.Products.GetAllProducts().AsQueryable();
        }

        public Product SearchProduct(Guid code)
        {
            return worker.Products.FindBy(pro => pro.Code == code).FirstOrDefault();
        }
    }
}
