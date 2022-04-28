using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorRPN.Model
{
    public static class TokenParser
    {
        static string patternExpression = @"(-?(\d+\.\d+)|(\d+))|[+|*|-|\/|\^|%|(|)]";
        static Regex regExExpression= new Regex(patternExpression);

        public static List<Token> GetTokenExpression(string inputExpression)
        {
            List<Token> tokenList = new List<Token>();
            foreach (Match match in regExExpression.Matches(inputExpression))
            {
                tokenList.Add(new Token(match.Value));
            }
            return tokenList;
        }
    }
}
