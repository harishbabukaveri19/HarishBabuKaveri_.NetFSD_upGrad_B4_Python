using System;
using System.Collections.Generic;
using System.Text;

namespace upGrad_Week6_Day1.Problem_Statement_2
{
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20; // For VIP Customers 20% discount
        }
    }
}
