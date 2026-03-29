using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_2
{
    public class PriceCalculator
    {
        public double CalculateFinalPrice(double amount, IDiscountStrategy discountStrategy)
        {
            double discount = discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }
}
