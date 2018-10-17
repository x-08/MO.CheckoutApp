using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutApp.Service.Interfaces;
using CheckoutAppDomain.DataModel.Repository;
using CheckoutAppDomain.Classes;

namespace CheckoutApp.Service
{
    public class InvoiceService : IInvoiceService
    {
        IUnitOfWork worker;
        public InvoiceService(IUnitOfWork worker)
        {
            this.worker = worker;
        }
        public void AddCheckedOutItemtoBill(int[] ItemIdArray)
        {
            List<CheckedoutProduct> products = new List<CheckedoutProduct>();
            double price = 0;
            foreach (var item in ItemIdArray)
            {
                var p = worker.CheckedoutProducts.GetById(item);
                if(p != null)
                {
                    price = p.Price;
                    products.Add(p);
                }
                else
                {
                    throw new ArgumentException($"Item-id {item} not present in cart");
                }
            }

            InvoiceDetails newInvoiceDetail = new InvoiceDetails()
            {
                MyProperty = products,
                Price = price,
                Time = DateTime.Now
            };

            if(newInvoiceDetail.MyProperty.Count > 0)
            {
                worker.InvoiceDetails.Add(newInvoiceDetail);
            }
            else
            {
                throw new ArgumentException($"Nothing Added from cart");
            }
            
        }

        public void DeleteCheckedOutItemtoBill(int ItemID)
        {
            throw new NotImplementedException();
        }

        public InvoiceDetails GenerateBill(int InvoiceId)
        {
            var invoice = worker.InvoiceDetails.GetById(InvoiceId);
            if(invoice != null)
            {
                return invoice;
            }
            else
            {
                throw new ArgumentException($"No Invoice with this ID");
            }
        }

       public IQueryable<InvoiceDetails> ListInvoices()
        {
            return worker.InvoiceDetails.GetAll().AsQueryable();
        }
    }
}
