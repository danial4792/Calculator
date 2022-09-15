using System;
using System.Collections;

namespace calculator
{
    class Calculator
    {

        public string GetResult(List<string> dividedExpression)
        {
            Program program = new();
            List<string> signs = program.rawSigns
                .Where(x => dividedExpression.Contains(x))
                .ToList();

            while (signs.Count() >= 1)
            {
                List<string> cloneExpression = dividedExpression
                        .Where(x => signs.Contains(x))
                        .ToList();
                
                if (dividedExpression.Contains("*") || dividedExpression.Contains("/"))
                {
                    cloneExpression = dividedExpression
                        .Where(x => !x.Equals("+") && !x.Equals("-"))
                        .ToList();
                }

                string controllerSign = cloneExpression
                    .First();

                if ((controllerSign == "-" && signs.Contains("+")) || (controllerSign == "/" && signs.Contains("*")))
                    calculate(dividedExpression, signs[1]);
                else
                    calculate(dividedExpression, signs[0]);

                signs = signs
                    .Where(x => dividedExpression.Contains(x))
                    .ToList();
            }

            return dividedExpression.First();
        }

        private void calculate(List<string> dividedExpression, string sign) 
        {
            int indexOfSign = dividedExpression.IndexOf(sign);

            switch (sign)
            {
                case "+":
                {
                    dividedExpression[indexOfSign] = (Double.Parse(dividedExpression[indexOfSign - 1]) + Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    dividedExpression.RemoveAt(indexOfSign - 1);
                    break;
                }
                case "-":
                {
                    dividedExpression[indexOfSign] = (Double.Parse(dividedExpression[indexOfSign - 1]) - Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    dividedExpression.RemoveAt(indexOfSign - 1);
                    break;
                }
                case "*":
                {
                    dividedExpression[indexOfSign] = (Double.Parse(dividedExpression[indexOfSign - 1]) * Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    dividedExpression.RemoveAt(indexOfSign - 1);
                    break;
                }
                case "/":
                {
                    dividedExpression[indexOfSign] = (Double.Parse(dividedExpression[indexOfSign - 1]) / Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    dividedExpression.RemoveAt(indexOfSign - 1);
                    break;
                }
                case "^":
                {
                    dividedExpression[indexOfSign] = Math.Pow(Double.Parse(dividedExpression[indexOfSign - 1]), Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    dividedExpression.RemoveAt(indexOfSign - 1);
                    break;
                }
                case "pi":
                {
                    dividedExpression[indexOfSign] = Math.PI
                        .ToString();
                    break;
                }
                case "sin":
                {
                    dividedExpression[indexOfSign] = Math.Sin(Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    break;
                }
                case "cos":
                {
                    dividedExpression[indexOfSign] = Math.Cos(Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    break;
                }
                case "tg":
                {
                    dividedExpression[indexOfSign] = Math.Tan(Double.Parse(dividedExpression[indexOfSign + 1]))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    break;
                }
                case "ctg":
                {
                    dividedExpression[indexOfSign] = (1 / Math.Tan(Double.Parse(dividedExpression[indexOfSign + 1])))
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    break;
                }
                case "deg":
                {
                    dividedExpression[indexOfSign] = (Double.Parse(dividedExpression[indexOfSign + 1]) / 180 * Math.PI)
                        .ToString();
                    dividedExpression.RemoveAt(indexOfSign + 1);
                    break;
                }
                case "(":
                {
                    List<String> subExpression = new();
                    while (subExpression.Where(x => x.Equals("(")).ToList().Count() > subExpression.Where(x => x.Equals(")")).ToList().Count() || !subExpression.Contains("(")) {
                        subExpression.Add(dividedExpression[indexOfSign]);
                        dividedExpression.RemoveAt(indexOfSign);
                    }
                    subExpression.Remove("(");
                    subExpression.RemoveAt(subExpression.LastIndexOf(")"));
                    dividedExpression.Insert(indexOfSign, GetResult(subExpression));
                    break;
                }
            }
        }
    }
}