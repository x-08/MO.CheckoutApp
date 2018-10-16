using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutApp.Service.Interfaces;
using CheckoutAppDomain.Classes;
using CheckoutAppDomain.Classes.Enumerations;
using CheckoutAppDomain.DataModel.Repository;

namespace CheckoutApp.Service
{
    public class CheckoutService : ICheckoutService
    {
        IUnitOfWork worker;
        public CheckoutService(IUnitOfWork worker)
        {
            this.worker = worker;
        }

        public void checkoutProduct(Product product, int Quantity)
        {
            var checkOut = new CheckedoutProduct
            {
                Product = product,
                Quantity = Quantity,
                Price = getFinalPrice(product, Quantity)
            };
            worker.CheckedoutProducts.Add(checkOut);
            worker.Complete();


        }

        public IQueryable<CheckedoutProduct> ListCheckedoutProducts()
        {
            return worker.CheckedoutProducts.GetCheckedoutProducts().AsQueryable();
        }

        public CheckedoutProduct SearchCheckedoutProduct(int Id)
        {
            return worker.CheckedoutProducts.FindBy(pro => pro.Id ==Id).FirstOrDefault();
        }

        private double getFinalPrice(Product product, int quantity)
        {

            double cost = product.Price * quantity;
            switch (product.Category)
            {
                case  Category.A:
                    cost = cost * 1.1;
                    break;
                case Category.B:
                    cost = cost * 1.2;
                    break;
                case Category.C:
                    cost = cost * 1;
                    break;
                default:
                    break;

            }
            return cost;

        }

    
    }
}
