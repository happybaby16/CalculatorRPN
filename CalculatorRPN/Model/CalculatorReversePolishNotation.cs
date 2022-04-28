using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorRPN.Model
{
    public class CalculatorReversePolishNotation
    {
        private List<Token> ToExpressionRPN(string inputExpression)
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
            //Записываем в выходной массив все оставшиеся операции в стеке
            for (int i = 0; i < operationsStack.Count; i++)
            {
                outputExpression.Add(operationsStack.Pop());
            }
            return outputExpression;
        }

        public double? Calculate(string inputExpression)
        {
            //null для того, чтобы быть уверенным в том, что программа посчитала всё без ошибок.
            //Например, при неправильном введенном арифметическом выражении
            double? resultCalculate = null;

            List<Token> tokens = ToExpressionRPN(inputExpression);
            Stack<double> numbersStack = new Stack<double>();
            try
            {
                foreach (Token token in tokens)
                {
                    if (token.Type == TypeToken.Number)
                    {
                        numbersStack.Push(Convert.ToDouble(token.Value.ToString()));
                    }
                    else if (token.Type == TypeToken.Operation)
                    {
                        double sOperand = numbersStack.Pop();
                        double fOperand = numbersStack.Pop();
                        string operation = token.Value.ToString();

                        double? resultCalculation = Calculator.Calculate(fOperand, sOperand, operation);
                        if (resultCalculation != null)
                        {
                            numbersStack.Push((double)resultCalculation);
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                }
                if(numbersStack.Count==1)
                {
                    resultCalculate = numbersStack.Pop();
                }
            }
            catch{}
            return resultCalculate;
        }
    }
}
