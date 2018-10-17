using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CheckoutApp.Service;
using CheckoutApp.Service.Interfaces;
using CheckoutAppDomain.Classes;
using CheckoutAppDomain.Classes.Enumerations;
using CheckoutAppDomain.DataModel;
using CheckoutAppDomain.DataModel.Repository;

namespace ConsoleClient
{
    class Program
    {

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<CheckoutService>().As<ICheckoutService>();
            builder.RegisterType<InvoiceService>().As<IInvoiceService>();
            builder.Register(c => new UnitOfWork(new CheckoutAppContext())).As<IUnitOfWork>();
            
            var container = builder.Build();

            var op = new Operations(container.Resolve<IProductService>(), container.Resolve<ICheckoutService>(),container.Resolve<IInvoiceService>());




            op.ShowProducts();

            Console.WriteLine("Enter Product Id to Add in cart");
            var id = Console.ReadLine();
            var intid = Convert.ToInt32(id);

            Console.WriteLine("Enter product quantity");
            var qty = Console.ReadLine();
            var intqty = Convert.ToInt32(id);

            op.CheckoutProduct(intid, intqty);

            Console.WriteLine("Showing checkedout products");
            op.showCheckedOutProducts();

            Console.WriteLine("Enter checkedout product id to Add in bill");
            var cid = Console.ReadLine();
            var intcid = Convert.ToInt32(cid);

            int[] productArray = new int[]
            {
                 intcid
            };


            op.AddProductToInvoice(productArray);

            Console.WriteLine("Showing Invoices");

            op.ListInvoices();


            Console.WriteLine("Enter invoice id to generate bill");
            var iid = Console.ReadLine();
            var intiid = Convert.ToInt32(cid);

            op.generateInvoice(intid);
            Console.Read();

                       
        }
    }
}
