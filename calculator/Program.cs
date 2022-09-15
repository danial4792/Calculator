using System;
using System.Collections;

namespace calculator
{
    class Program
    {
        public List<string> rawSigns = new()
        {
            "pi", "(", ")", "^", "deg", "sin", "cos", "tg", "ctg", "*", "/", "+", "-"
        };
        
        static void Main(string[] args)
        {

            Input input = new();
            Calculator calculator = new();

            string expression = Console.ReadLine()!;

            expression = expression
                .Trim()
                .Replace(" ", "");

            List<string> dividedExpression = input.GetExpression(expression);
            
            string result = calculator.GetResult(dividedExpression);
            Console.WriteLine(result);
        }
    }
}