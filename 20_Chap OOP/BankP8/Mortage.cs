using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Mortage : Account
    {
        public int balance { get; set; }
        public Customer customer { get; set; }

        public double InterestRate(int month)
        {
            if (customer.GetType().Name == "Company")
            {
                if (month <= 12)
                {
                    return month * (0.5 * balance);
                }
                else
                {
                    return month * (0.25 * balance);
                }
            }
            else
            {
                if (month <= 6)
                {
                    return 0;
                }
                else
                {
                    return month * (0.25 * balance);
                }
            }
        }

        public void DepositAmount(int amount)
        {
            balance += amount;
        }

        public void CurrentBalance()
        {
            Console.WriteLine("Your Current Balance: " + balance);
        }


    }
}
