using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutApp.Service.PriceCalculator
{
    public class Calculator
    {
        private IPriceCalculator pricecal;
        public Calculator(IPriceCalculator cal)
        {
            this.pricecal = cal;
        }

        public double calculate(double cost)
        {
            return this.pricecal.calculate(cost);
        }
    }

    public class ACalculator : IPriceCalculator
    {
        public double calculate(double cost)
        {
            return cost * 1.1;
        }
    }
    public class BCalculator : IPriceCalculator
    {
        public double calculate(double cost)
        {
            return cost * 1.2;
        }
    }
    public class CCalculator : IPriceCalculator
    {
        public double calculate(double cost)
        {
            return cost * 1;
        }
    }
}
