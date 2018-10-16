using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutAppDomain.DataModel.Repository
{
    public interface IInvoiceDetailsRepository : IRepository<InvoiceDetails>
    {
        IEnumerable<InvoiceDetails> GetInvoice();
    }
}
