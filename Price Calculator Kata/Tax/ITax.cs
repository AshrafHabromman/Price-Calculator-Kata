using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Price_Calculator_Kata
{
    public  interface ITax
    {
        float taxPercentage { get; set; }
        public float CalculateTax(float price);
    }
}   
