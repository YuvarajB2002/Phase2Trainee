using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekEndTask
{
    internal class TemporaryEmployee : Employee
    {
        public int DailyWages { get; set; }
        public int NoOfDays { get; set; }

        public override float CalculateSalary(int id, string name, float basicSalary)
        {
            NetSalary = DailyWages * NoOfDays;
            return NetSalary;
        }

        public override float CalculateBonus(float salary, int criteria)
        {
            if (DailyWages < 1000)
            {
                Bonus = 0.15f * NetSalary;
            }
            else if (DailyWages >= 1000 && DailyWages < 1500)
            {
                Bonus = 0.12f * NetSalary;
            }
            else if (DailyWages >= 1500 && DailyWages < 1750)
            {
                Bonus = 0.11f * NetSalary;
            }
            else
            {
                Bonus = 0.08f * NetSalary;
            }
            return Bonus;
        }
    }
}
