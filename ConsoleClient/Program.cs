using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutApp.Service;
using CheckoutAppDomain.Classes;
using CheckoutAppDomain.Classes.Enumerations;
using CheckoutAppDomain.DataModel;
using CheckoutAppDomain.DataModel.Repository;

namespace ConsoleClient
{
    class Program
    {

        public static void insertData()
        {
            var context = new CheckoutAppContext();
            var unitofwork = new UnitOfWork(context);
            ProductService ps = new ProductService(unitofwork);
            var product = new Product()
            {
                Name = "AppleXS",
                Code = Guid.Parse("47896e89-9b37-40e4-a3f9-430de3d28284"),
                Category = Category.A,
                Price = 100000

            };
            ps.AddProduct(product);

        }

        public static void insertCheckedOutItem()
        {

            var context = new CheckoutAppContext();
            using (var unitofwork = new UnitOfWork(context))
            {
                var p = unitofwork.Products.GetAllProducts();
            }
            //ProductRepository pr = new ProductRepository(context);
            //var p  = pr.GetAllProducts();
            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Inserting Product");
            Program.insertData();
            Console.WriteLine("Insertion Complete");
            Console.Read();
        }
    }
}
