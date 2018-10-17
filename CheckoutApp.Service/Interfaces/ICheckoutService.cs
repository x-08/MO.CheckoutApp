using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckoutAppDomain.Classes;

namespace CheckoutApp.Service.Interfaces
{
    public interface ICheckoutService
    {
        void checkoutProduct(int ProductId, int Quantity);
        CheckedoutProduct SearchCheckedoutProduct(int id);
        IQueryable<CheckedoutProduct> ListCheckedoutProducts();
        void deleteCheckedOutProduct(int ProductId);

    }
}
