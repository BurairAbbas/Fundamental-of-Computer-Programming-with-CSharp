using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Deposit : Account
    {
        public int balance { get; set; }
        public Customer customer { get; set; }
        
        /// <summary>
        /// Calculate Interest rate according to customer to customer
        /// </summary>
        /// <param name="month">period in you will pay amount back </param>
        /// <returns>return the calculated interested amount </returns>
        public double InterestRate(int month)
        {
            if (balance < 0 || balance < 1000)
            {
                return 0;
            }
            else
            {
                return month * (0.25*balance); // number of month * interest rate
            }
        }
        /// <summary>
        /// Deposit amount in user account
        /// </summary>
        /// <param name="amount">amount you want to add</param>
        public void DepositAmount(int amount)
        {            
            balance += amount;
        }
        /// <summary>
        /// Withdraw amount from account
        /// </summary>
        /// <param name="amount">amount you want to withdraw</param>
        /// <returns>return balance account</returns>
        public int WithdrawAmount(int amount)
        {
            if (balance > amount)
            {
                balance -= amount;
                return balance;
            }
            return 0;
        }
        /// <summary>
        /// display the current amount in account
        /// </summary>
        public void CurrentBalance()
        {
            Console.WriteLine("Your Current Balance: " + balance);
        }
    }
}
