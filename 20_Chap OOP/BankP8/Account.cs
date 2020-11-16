using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public interface Account
    {
        /// <summary>
        /// To get and set the amount of customer
        /// </summary>
        int balance { get; set; }

        //Aggregation relation: Account to customer, might be their is no account active but their is customer;
       Customer customer { get; set; }

        /// <summary>
        /// To return the interest rate 
        /// </summary>
        /// <param name="month">number of months payment by customer</param>
        /// <returns>return interested rate </returns>
        double InterestRate(int month);
    }
}
