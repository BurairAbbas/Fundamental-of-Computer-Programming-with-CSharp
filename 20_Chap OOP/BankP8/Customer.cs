using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Customer
    {
        protected string firstName;
        protected string lastName;

        //Composition: if there is no customer than their is no account of that particular customer.
        // only way u can assess account by Customer;

        public Deposit Deposit { get; set; } 
        public Loan Loan { get; set; }
        public Mortage Mortage { get; set; }
        
        public Customer()
        {
            Deposit = new Deposit();
            Loan = new Loan();
            Mortage = new Mortage();
            // to get the name of derived class
            //Console.WriteLine("Customer called from: " + this.GetType().Name);
        }        
    }
}
