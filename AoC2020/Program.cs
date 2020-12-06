﻿using System;
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

            //Console.WriteLine();
            //Console.WriteLine("Day 2 Part 1:");
            //Day2Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 2 Part 2:");
            //Day2Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 3 Part 1:");
            //Day3Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 3 Part 2:");
            //Day3Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 4:");
            //Day4();

            //Console.WriteLine();
            //Console.WriteLine("Day 5 Part 1:");
            //Day5Part1();

            Console.WriteLine();
            Console.WriteLine("Day 5 Part 2:");
            Day5Part2();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        public static void Day5Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day5A.txt");

            SeatFinder sf = new SeatFinder();
            sf.FindHighestID(inputs, 127, 7);
            int output = sf.FindMySeat();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Find highest seat ID
        // Answer = 806
        public static void Day5Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day5A.txt");

            SeatFinder sf = new SeatFinder();
            int output = sf.FindHighestID(inputs, 127, 7);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer A = 260
        // Answer B = 153
        public static void Day4()
        {
            Console.WriteLine("Parsing Input...");
            string[] input = File.ReadAllLines("Inputs/Day4A.txt");

            PassportValidator pv = new PassportValidator(new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" }, new string[] { "cid" });
            int output = pv.CountValidPassports(input);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 958815792
        public static void Day3Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day3A.txt");

            TobogganTraversal tt = new TobogganTraversal(inputs);
            List<int> outputVals = new List<int>();
            outputVals.Add(tt.CollisionDetector(0, 0, 3, 1));
            outputVals.Add(tt.CollisionDetector(0, 0, 1, 1));
            outputVals.Add(tt.CollisionDetector(0, 0, 5, 1));
            outputVals.Add(tt.CollisionDetector(0, 0, 7, 1));
            outputVals.Add(tt.CollisionDetector(0, 0, 1, 2));

            int output = 1;

            foreach(int outputVal in outputVals)
            {
                output *= outputVal;
            }

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 232
        public static void Day3Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day3A.txt");

            TobogganTraversal tt = new TobogganTraversal(inputs);
            int output = tt.CollisionDetector(0, 0, 3, 1);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        public static void Day2Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day2A.txt");

            int output = PasswordValidator.CountValidPasswordsNew(inputs);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
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
