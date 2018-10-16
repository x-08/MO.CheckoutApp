using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutAppDomain.DataModel.Repository
{
    public class InvoiceDetailsRepository : Repository<InvoiceDetails>, IInvoiceDetailsRepository
    {
        public InvoiceDetailsRepository(DbContext context) : base(context)
        {
        }

        public CheckoutAppContext CheckoutAppContext
        {
            get { return Context as CheckoutAppContext; }
        }

        public IEnumerable<InvoiceDetails> GetInvoice()
        {
            return CheckoutAppContext.invoiceDetails.ToList();
        }
    }
}
