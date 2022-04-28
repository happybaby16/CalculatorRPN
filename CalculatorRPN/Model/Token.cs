using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorRPN.Model
{
    public enum TypeToken
    { 
        Number = 1,
        Operation = 2,
        Braket = 3
    }
    public class Token
    {
        public object Value { get; set; }
        public TypeToken? Type
        {
            get => GetTokenType();
        }
        private TypeToken? GetTokenType()
        {
            if (Regex.IsMatch(Value.ToString(), @"(-?(\d+\.\d+)|(\d+))")) return TypeToken.Number;
            else if (Regex.IsMatch(Value.ToString(), @"[+|*|-|\/|\^|%]")) return TypeToken.Operation;
            else if (Regex.IsMatch(Value.ToString(), "[(|)]")) return TypeToken.Braket;
            else return null;
        }
        public int? Priority
        {
            get => GetPriority();
        }
        public int? GetPriority()
        {
            if (Type == TypeToken.Operation || Type == TypeToken.Braket)
            {
                switch (Value.ToString())
                {
                    case "(":
                        return 1;
                    case ")":
                        return 1;
                    case "+":
                        return 2;
                    case "-":
                        return 2;
                    case "*":
                        return 3;
                    case "/":
                        return 3;
                    case "^":
                        return 4;
                }
            }
            return null; 
        }

        public Token(object tokenValue)
        {
            Value = tokenValue;
        }
    }
}
