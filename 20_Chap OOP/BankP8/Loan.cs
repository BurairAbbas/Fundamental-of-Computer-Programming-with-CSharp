using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Loan : Account
    {
        public int balance { get; set; }
        public Customer customer { get; set; }

        // this way u can encapsulate customer class too
        //public Loan(Customer customer)
        //{
        //    this.customer = customer;
        //}

        public double InterestRate(int month)
        {
            // if customer is company than apply this condition
            if (customer.GetType().Name == "Company") // GetType used to get the name of class
            {
                if (month <= 2)
                {
                    return 0;
                }
                else
                {
                    return month * (0.25 * balance);
                }
            }
            else
            {
                if (month <= 3)
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
