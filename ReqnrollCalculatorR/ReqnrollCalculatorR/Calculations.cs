using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollCalculatorR
{
    public class Calculations
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }
        
        public int  numberIs { get; set; }
        public int AddNumbers()
        {
            return FirstNumber + SecondNumber;
        }

        public int SubtractNumbers()
        {
            return FirstNumber - SecondNumber;
        }

        public int MultiplyNumbers()
        {
            return FirstNumber * SecondNumber;
        }

        public int DivideNumbers()
        {
            if(SecondNumber == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return FirstNumber / SecondNumber;

        }

        public string CheckEvenOrOdd()
            {
                if (numberIs % 2 == 0)
                {
                    return "even";
                }
                else
                {
                    return "odd";
                }
        }
    }
}
