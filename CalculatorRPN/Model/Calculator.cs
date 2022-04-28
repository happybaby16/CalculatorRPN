using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorRPN.Model
{
    public static class Calculator
    {
        public static double? Calculate(double fOperand, double sOperand, string operation)
        {
            switch (operation)
            {
                case "+": return fOperand + sOperand;
                case "-": return fOperand - sOperand;
                case "*": return fOperand * sOperand;
                case "/": return fOperand / sOperand;
                case "^": return Math.Pow(fOperand, sOperand);
            }
            return null;
        }
    }
}
