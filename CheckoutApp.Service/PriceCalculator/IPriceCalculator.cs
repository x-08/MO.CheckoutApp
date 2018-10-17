using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutApp.Service.PriceCalculator
{
    public interface IPriceCalculator
    {
        double calculate(double cost);
    }

 }
