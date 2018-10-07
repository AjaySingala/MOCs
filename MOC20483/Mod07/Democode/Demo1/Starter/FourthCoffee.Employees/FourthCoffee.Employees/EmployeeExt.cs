using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.Employees
{
    public partial class Employee
    {
        private void OnDateOfBirthChanging(DateTime? date)
        {
            if (GetAge() < 16)
            {
                throw new Exception("Employees must be over 16.");
            }
        }

        private int GetAge()
        {
            DateTime DOB = (DateTime)DateOfBirth;
            TimeSpan difference = DateTime.Now.Subtract(DOB);
            int ageInYears = (int)(difference.Days / 365.25);

            return ageInYears;
        }
    }
}
