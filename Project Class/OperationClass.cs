using System;
using System.Linq;

namespace CalculatorWebApp.Project_Class
{
    internal class OperationClass
    {
        public double ProcessExpression(string input)
        {
            char[] operators = new char[] { '+', '-', '*', '/' };
            string[] numbers = input.Split(operators);

            double result = double.Parse(numbers[0]);

            int currentIndex = numbers[0].Length;

            for (int i = 1; i < numbers.Length; i++)
            {
                char currentOperator = input[currentIndex];
                double nextNumber = double.Parse(numbers[i]); 

                switch (currentOperator)
                {
                    case '+':
                        result += nextNumber;
                        break;
                    case '-':
                        result -= nextNumber;
                        break;
                    case '*':
                        result *= nextNumber;
                        break;
                    case '/':
                        result /= nextNumber;
                        break;
                }

                currentIndex += numbers[i].Length + 1;
            }

            return result;
        }
    }
}
