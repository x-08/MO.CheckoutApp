using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutApp.Service.Interfaces;
using CheckoutAppDomain.Classes;

namespace ConsoleClient
{
    public class Operations
    {
        private readonly IProductService _svc;
        private readonly ICheckoutService _csvc;
        private readonly IInvoiceService _isvc;

        public Operations(IProductService svc, ICheckoutService csvc ,IInvoiceService isvc)
        {
            _svc = svc;
            _csvc = csvc;
            _isvc = isvc;
        }

        public void InsertProduct(Product product)
        {
            _svc.AddProduct(product);
        }
        public void ShowProducts()
        {
            var productList = _svc.ListProducts();
            Console.WriteLine($"Products Available");
            foreach (var p in productList)
            {
               
                Console.WriteLine($"{p.Id}----{p.Name}----{p.Price}");
            }
        }
        public void CheckoutProduct(int ProductId, int Quantity)
        {
            _csvc.checkoutProduct(ProductId, Quantity);
        }

        public void showCheckedOutProducts()
        {
            var p = _csvc.ListCheckedoutProducts();
            foreach (var item in p)
            {
                Console.WriteLine($"{item.Id}-----{item.Price}");
            }
        }
        public void DeleteCheckedOutProduct(int ProductId)
        {
            _csvc.deleteCheckedOutProduct(ProductId);
        }


        public void AddProductToInvoice(int[] CheckedoutProductIDs)
        {
            _isvc.AddCheckedOutItemtoBill(CheckedoutProductIDs);

        }

        public void ListInvoices()
        {
            var invoices = _isvc.ListInvoices();
            foreach (var item in invoices)
            {
                Console.WriteLine($"{item.Id}----{item.Price}---{item.Time}");

            }
        }

        public void generateInvoice(int id)
        {
            var invoice = _isvc.GenerateBill(id);

            Console.WriteLine($"***********************************************************************");
            Console.WriteLine($"{invoice.Id}----{invoice.Price}---{invoice.Time}");
       
                foreach (var product in invoice.MyProperty)
                {
                    Console.WriteLine($"{product.Product.Name}-----{product.Quantity}----{product.Price}");
                }


            Console.WriteLine($"***********************************************************************");
            
        }
    }
}
