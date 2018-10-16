using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAppDomain.DataModel.Repository
{
    public  interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICheckedoutProduct CheckedoutProducts { get; }
        IInvoiceDetailsRepository InvoiceDetails { get; }
        int Complete();
    }
}
