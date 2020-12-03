using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2020
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine();
            //Console.WriteLine("Day 1 Part 1:");
            //Day1Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 1 Part 2:");
            //Day1Part2();

            Console.WriteLine();
            Console.WriteLine("Day 2 Part 1:");
            Day2Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 2 Part 2:");
            //Day2Part2();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        // Answer = 643
        public static void Day2Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day2A.txt");

            int output = PasswordValidator.CountValidPasswords(inputs);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        public static void Day1Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] input = File.ReadAllLines("Inputs/Day1A.txt");

            HashSet<int> expenseTable = new HashSet<int>();

            foreach (string str in input)
            {
                expenseTable.Add(Convert.ToInt32(str));
            }

            int output = ExpenseFinder.FindJointProduct(expenseTable);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        public static void Day1Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] input = File.ReadAllLines("Inputs/Day1A.txt");

            HashSet<int> expenseTable = new HashSet<int>();

            foreach (string str in input)
            {
                expenseTable.Add(Convert.ToInt32(str));
            }

            int output = ExpenseFinder.FindProduct(expenseTable);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }
    }
}
