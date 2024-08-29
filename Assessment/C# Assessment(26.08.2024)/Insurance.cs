using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1
{
    internal class Insurance
    {
        private string insuranceNo;
        private string insuranceName;
        private double amountCovered;

        public string InsuranceNo
        {
            get { return insuranceNo; }
            set { insuranceNo = value; }
        }
        public double AmountCovered
        {
            get { return amountCovered; }
            set { amountCovered = value; }
        }
        public string InsuranceName
        {
            get { return insuranceName; }
            set { insuranceName = value; }

        }
    }
}
