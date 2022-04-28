using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorRPN.Model
{
    public class CalculatorReversePolishNotation
    {
        public string InputExpression { get; set; } = string.Empty;


        public List<Token> ToExpressionRPN(string inputExpression)
        {
            List<Token> outputExpression = new List<Token>();

            List<Token> tokens = TokenParser.GetTokenExpression(inputExpression);
            Stack<Token> operationsStack = new Stack<Token>();
            foreach (Token token in tokens)
            {
                if (token.Type == TypeToken.Number)
                {
                    outputExpression.Add(token);
                }
                else if (token.Type == TypeToken.Operation)
                {
                    if (operationsStack.Count == 0)
                    {
                        operationsStack.Push(token);
                    }
                    else if (operationsStack.Count != 0 && operationsStack.Peek().Priority < token.Priority)
                    {
                        operationsStack.Push(token);
                    }
                    else if (operationsStack.Count != 0 && operationsStack.Peek().Priority >= token.Priority)
                    {
                        outputExpression.Add(operationsStack.Pop());
                        operationsStack.Push(token);
                    }
                }
                else if (token.Type == TypeToken.Braket)
                {
                    if (token.Value.ToString() == "(")
                    {
                        operationsStack.Push(token);
                    }
                    else
                    {
                        for (int i = 0; i < operationsStack.Count; i++)
                        {
                            if (operationsStack.Peek().Type != TypeToken.Braket)
                            {
                                outputExpression.Add(operationsStack.Pop());
                            }
                            else
                            {
                                operationsStack.Pop();
                                break;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < operationsStack.Count; i++)
            {
                outputExpression.Add(operationsStack.Pop());
            }

            return outputExpression;
        }


    }
}
