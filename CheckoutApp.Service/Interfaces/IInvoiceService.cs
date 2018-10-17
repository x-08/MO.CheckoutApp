using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutApp.Service.Interfaces
{
    public interface IInvoiceService
    {
        void AddCheckedOutItemtoBill(int[] itemIdArray);
        InvoiceDetails GenerateBill(int InvoiceId);
        IQueryable<InvoiceDetails> ListInvoices();
    }
}
