using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutAppDomain.DataModel.Repository
{
    public class CheckedoutProductsRepository : Repository<CheckedoutProduct>, ICheckedoutProduct
    {
        public CheckedoutProductsRepository(DbContext context) : base(context)
        {
        }

        public CheckoutAppContext CheckoutAppContext
        {
            get { return Context as CheckoutAppContext; }
        }

        public IEnumerable<CheckedoutProduct> GetCheckedoutProducts()
        {
            return CheckoutAppContext.checkedoutProducts.ToList();
        }
    }
}
