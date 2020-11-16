using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class Individual : Customer
    {
        public Individual()
        {
            Deposit.customer = this;
            Loan.customer = this;
            Mortage.customer = this;
        }

        public string FirstName
        {
            get
            {
                return base.firstName;
            }
            set
            {
                base.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return base.lastName;
            }
            set
            {
                base.lastName = value;
            }
        }

        public override string ToString()
        {
            return "Name: " + FirstName + "Last Name: " + LastName;
        }
    }
}
