using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutAppDomain.DataModel.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CheckoutAppContext _context;

        public UnitOfWork(CheckoutAppContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            CheckedoutProducts = new CheckedoutProductsRepository(_context);
            InvoiceDetails = new InvoiceDetailsRepository(_context);

        }

        public IProductRepository Products { get; private set; }

        public ICheckedoutProduct CheckedoutProducts { get; private set; }

        public IInvoiceDetailsRepository InvoiceDetails { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
