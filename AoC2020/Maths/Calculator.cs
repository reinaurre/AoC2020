using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Maths
{
    public static class Calculator
    {
        public static long EvaluateExpression(string input)
        {
            Stack<long> numbers = new Stack<long>();
            Stack<Operation> operations = new Stack<Operation>();

            input = input.Replace(" ", "");

            foreach (char c in input)
            {
                switch (c)
                {
                    case '+': operations.Push(Operation.Addition); break;
                    case '*': operations.Push(Operation.Multiplication); break;
                    case '(': operations.Push(Operation.OpenParen); break;
                    case ')':
                        if (operations.Peek() == Operation.OpenParen)
                        {
                            operations.Pop();
                        }
                        while (operations.Count > 0 && operations.Peek() != Operation.OpenParen)
                        {
                            Operation op = operations.Pop();
                            long a = numbers.Pop();
                            long b = numbers.Pop();

                            numbers.Push(DoOperation(op, a, b));
                        }
                        break;
                    default:
                        long num = long.Parse(c.ToString());
                        if (operations.Count > 0 && operations.Peek() != Operation.OpenParen)
                        {
                            Operation op = operations.Pop();
                            long b = numbers.Pop();
                            numbers.Push(DoOperation(op, num, b));
                        }
                        else
                        {
                            numbers.Push(num);
                        }
                        break;
                }
            }

            while (operations.Count > 0)
            {
                Operation op = operations.Pop();
                long a = numbers.Pop();
                long b = numbers.Pop();

                numbers.Push(DoOperation(op, a, b));
            }

            return numbers.Pop();
        }

        public static string PrioritizeAddition(string input)
        {
            List<char> inputList = input.Replace(" ", "").ToList();

            int index = inputList.IndexOf('+');
            while (index > 0)
            {
                int startIndex;
                int endIndex;

                if (inputList[index + 1] == '(')
                {
                    int i = 1;
                    int parenCount = 0;
                    while ((index + i) < inputList.Count)
                    {
                        if (inputList[index + i] == '(')
                        {
                            parenCount++;
                        }
                        else if (inputList[index + i] == ')')
                        {
                            parenCount--;
                        }
                        else if (parenCount == 0)
                        {
                            break;
                        }
                        i++;
                    }
                    endIndex = index + i;
                }
                else
                {
                    endIndex = index + 2;
                }
                inputList.Insert(endIndex, ')');

                if (inputList[index - 1] == ')')
                {
                    int i = 1;
                    int parenCount = 0;
                    while ((index + i) >= 0)
                    {
                        if (inputList[index - i] == '(')
                        {
                            parenCount++;
                        }
                        else if(inputList[index - i] == ')')
                        {
                            parenCount--;
                        }
                        else if (parenCount == 0)
                        {
                            break;
                        }
                        i++;
                    }
                    startIndex = index - i;
                }
                else
                {
                    startIndex = index - 1;
                }
                inputList.Insert(startIndex, '(');

                index = inputList.IndexOf('+', index + 2);
            }

            StringBuilder sb = new StringBuilder();

            foreach(char c in inputList)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        // I don't understand how this one works and mine above doesn't.  They're practically identical.
        public static string ConvertForPart2(string expression)
        {
            var e2 = expression.Replace(" ", "").ToList();

            int index = e2.IndexOf('+');
            while (index > 0)
            {
                int rearIndex;
                int frontIndex;
                if (e2[index + 1] == '(')
                {
                    int i = 1;
                    int parenCount = 0;
                    while ((index + i) < e2.Count)
                    {
                        if (e2[index + i] == '(') parenCount++;
                        if (e2[index + i] == ')') parenCount--;
                        if (parenCount == 0) break;
                        i++;
                    }
                    rearIndex = index + i;

                }
                else rearIndex = index + 2;
                e2.Insert(rearIndex, ')');

                if (e2[index - 1] == ')')
                {
                    int i = 1;
                    int parenCount = 0;
                    while ((index + i) >= 0)
                    {
                        if (e2[index - i] == '(') parenCount++;
                        if (e2[index - i] == ')') parenCount--;
                        if (parenCount == 0) break;
                        i++;
                    }
                    frontIndex = index - i;
                }
                else frontIndex = index - 1;
                e2.Insert(frontIndex, '(');

                index = e2.IndexOf('+', index + 2);
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in e2)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }

        private static long DoOperation(Operation operation, long leftValue, long rightValue)
        {
            switch (operation)
            {
                case Operation.Addition: return leftValue + rightValue;
                case Operation.Multiplication: return leftValue * rightValue;
                default: return int.MinValue;
            }
        }
    }

    public enum Operation
    {
        None,
        Addition,
        Multiplication,
        OpenParen,
        CloseParen
    }
}
