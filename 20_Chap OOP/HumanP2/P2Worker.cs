using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chap20OOP
{
    public class P2Worker : Human, IComparable<P2Worker>
    {
        private int wage;
        private int hours;

        public P2Worker(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public int Wage
        {
            get
            {
                return wage;
            }
            set
            {
                wage = value;
            }
        }

        public int Hours
        {
            get
            {
                return hours;
            }
            set
            {
                hours = value;
            }
        }

        public int CalculateHourlyWage(int wage, int hours)
        {
            this.Wage = wage;
            this.Hours = hours;
            return Hours * Wage;
        }

        public int CompareTo(P2Worker other)
        {
            int currentWage = CalculateHourlyWage(this.Wage, this.Hours);
            // if i called Calculate method here, its changing this.wage into other.wage in method, which costing all value change into one.
            int otherWage = other.Wage * other.Hours;
            if (currentWage > otherWage)
                return -1;
            else if (currentWage < otherWage)
                return 1;
            else
                return 0;
        }

        public override string ToString()
        {
            return "First Name: "+ this.FirstName +" Last Name: " +this.LastName + "Salary: " + (CalculateHourlyWage(this.Wage, this.Hours));
        }

    }
}
