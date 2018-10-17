using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutApp.Service.Interfaces;
using CheckoutApp.Service.PriceCalculator;
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

        public void checkoutProduct(int ProductId, int Quantity)
        {
            var product = worker.Products.GetById(ProductId);
            if (product != null)
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
            else
            {
                throw new ArgumentException("Product doesnt exist");
            }



        }

        public void deleteCheckedOutProduct(int ProductId)
        {
            var product = worker.Products.GetById(ProductId);
           if(product != null)
            {
                worker.CheckedoutProducts.Delete(product);
            }
            else
            {
                throw new ArgumentException("Product doesnt exist in cart");
            }
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

            Calculator cal;
            switch (product.Category)
            {
                case  Category.A:
                    cal = new Calculator(new ACalculator());
                    cost = cal.calculate(cost);
                    break;
                case Category.B:
                    cal = new Calculator(new BCalculator());
                    cost = cal.calculate(cost);
                    break;
                case Category.C:
                    cal = new Calculator(new CCalculator());
                    cost = cal.calculate(cost);
                    break;
                default:
                    break;

            }
            return cost;

        }

    
    }
}
