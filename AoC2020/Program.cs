using AoC2020.Computer;
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

            //Console.WriteLine();
            //Console.WriteLine("Day 5 Part 2:");
            //Day5Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 6 Part 1:");
            //Day6Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 6 Part 2:");
            //Day6Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 7 Part 1:");
            //Day7Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 7 Part 2:");
            //Day7Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 8 Part 1:");
            //Day8Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 8 Part 2:");
            //Day8Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 9 Part 1:");
            //Day9Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 9 Part 2:");
            //Day9Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 10 Part 1:");
            //Day10Part1();

            Console.WriteLine();
            Console.WriteLine("Day 10 Part 2:");
            Day10Part2();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        // Answer = 453551299002368
        public static void Day10Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day10A.txt");

            List<int> inputNums = new List<int>();
            foreach (string str in inputs)
            {
                inputNums.Add(Convert.ToInt32(str));
            }

            JoltageAdapter ja = new JoltageAdapter(inputNums);
            long output = ja.CountCombinations();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 2432
        public static void Day10Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day10A.txt");

            List<int> inputNums = new List<int>();
            foreach (string str in inputs)
            {
                inputNums.Add(Convert.ToInt32(str));
            }

            JoltageAdapter ja = new JoltageAdapter(inputNums);
            int output = ja.DiffProduct(3);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 51152360
        public static void Day9Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day9A.txt");

            List<long> inputNums = new List<long>();
            foreach (string str in inputs)
            {
                inputNums.Add(Convert.ToInt64(str));
            }

            XMAScracker xc = new XMAScracker();
            xc.FindRuleBreaker(25, inputNums.ToArray());
            long output = xc.FindWeakness();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 373803594
        public static void Day9Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day9A.txt");

            List<long> inputNums = new List<long>();
            foreach(string str in inputs)
            {
                inputNums.Add(Convert.ToInt64(str));
            }

            XMAScracker xc = new XMAScracker();
            long output = xc.FindRuleBreaker(25, inputNums.ToArray());

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 1235
        public static void Day8Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day8A.txt");

            BootCodeRunner bcr = new BootCodeRunner(inputs);
            bcr.FixCorruption();
            int output = bcr.ExecuteCode();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 1859
        public static void Day8Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day8A.txt");

            BootCodeRunner bcr = new BootCodeRunner(inputs);
            int output = bcr.ExecuteCode_BreakOnLoop();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 108636
        public static void Day7Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day7A.txt");

            BagPacker bp = new BagPacker();
            bp.ParseRules(inputs);
            int output = bp.GetTotalContents("shiny gold");

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 101
        public static void Day7Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day7A.txt");

            BagPacker bp = new BagPacker();
            bp.ParseRules(inputs);
            int output = bp.CountAncestors("shiny gold");

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 3219
        public static void Day6Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day6A.txt");

            int output = AnswerChecker.CountUnanimousGroupAnswers(inputs);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 6596
        public static void Day6Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day6A.txt");

            int output = AnswerChecker.CountGroupAnswers(inputs);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
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
