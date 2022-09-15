using System;
using System.Collections;

namespace calculator
{
    class Input
    {

        public List<string> GetExpression(string expression)
        {
            Program program = new();
            string cloneExpression = expression;
            List<string> dividedExpression = new();

            while (cloneExpression.Length > 0)
                dividedExpression.Add(SiftSigns(ref cloneExpression, dividedExpression));
            
            return dividedExpression;
        }

        public string SiftSigns(ref string expression, List<string> dividedExpression)
        {
            string result = "";
            Program program = new();

            for (int i = 0; i < expression.Length; i++)
            {
                if (program.rawSigns.Contains(expression.Substring(0, i + 1)))
                {
                    result = expression.Substring(0, i + 1);
                    if (!((dividedExpression.Count > 0 && IsOperator(dividedExpression.Last().Last())) && IsOperator(result.Last()) && Char.IsDigit(expression[i + 1])))
                        break;
                }
                else if (Char.IsDigit(expression[i]) || expression[i].Equals("."))
                {
                    result = expression.Substring(0, i + 1);
                    if (expression.Length > i + 1 && !Char.IsDigit(expression[i + 1]) && !expression[i + 1].Equals("."))
                        break;
                }
            }

            expression = expression.Substring(result.Length);
            return result;
        }

        public bool IsOperator(char sign)
        {
            return !Char.IsDigit(sign) && !Char.IsLetter(sign) && !sign.Equals("(");
        }
    }
}