using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_2
{
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }
}
