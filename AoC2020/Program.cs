using AoC2020.Computer;
using AoC2020.ConwayCubes;
using AoC2020.Maths;
using AoC2020.Navigation;
using AoC2020.NewFolder;
using AoC2020.Seating;
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

            //Console.WriteLine();
            //Console.WriteLine("Day 10 Part 2:");
            //Day10Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 11 Part 1:");
            //Day11Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 11 Part 2:");
            //Day11Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 12 Part 1:");
            //Day12Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 12 Part 2:");
            //Day12Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 13 Part 1:");
            //Day13Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 13 Part 2:");
            //Day13Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 14 Part 1:");
            //Day14Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 14 Part 2:");
            //Day14Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 15 Part 1:");
            //Day15Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 15 Part 2:");
            //Day15Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 16 Part 1:");
            //Day16Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 16 Part 2:");
            //Day16Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 17 Part 1:");
            //Day17Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 17 Part 2:");
            //Day17Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 18 Part 1:");
            //Day18Part1();

            //Console.WriteLine();
            //Console.WriteLine("Day 18 Part 2:");
            //Day18Part2();

            //Console.WriteLine();
            //Console.WriteLine("Day 19 Part 1:");
            //Day19Part1();

            Console.WriteLine();
            Console.WriteLine("Day 19 Part 2:");
            Day19Part2();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        // Answer = 
        public static void Day19Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day19A.txt");

            SatelliteMessaging2 sm = new SatelliteMessaging2();
            int output = sm.GetRuleZeroMatches(inputs);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 184
        public static void Day19Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day19A.txt");

            SatelitteMessaging sm = new SatelitteMessaging();
            int output = sm.GetRuleZeroMatches(inputs);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 
        public static void Day18Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day18A.txt");

            long output = 0;
            foreach (string input in inputs)
            {
                output += Calculator.EvaluateExpression(Calculator.ConvertForPart2(input));
            }

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 30753705453324
        public static void Day18Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day18A.txt");

            long output = 0;
            foreach(string input in inputs)
            {
                output += Calculator.EvaluateExpression(input);
            }

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 
        public static void Day17Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day17A.txt");

            BootSystemStolen bss = new BootSystemStolen(inputs, true);

            BootSystem bs = new BootSystem(inputs);
            bs.RunBootSequence(6);
            int output = bs.GetActiveCount();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 
        public static void Day17Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day17A.txt");

            BootSystemStolen bss = new BootSystemStolen(inputs);

            BootSystem bs = new BootSystem(inputs);
            bs.RunBootSequence(6);
            int output = bs.GetActiveCount();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 
        public static void Day16Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day16A.txt");

            TicketScanner ts = new TicketScanner(inputs);
            ts.FindScanningErrorRate(true);
            ts.IdentifyFields();
            long output = ts.GetDepartureProduct();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 26988
        public static void Day16Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day16A.txt");

            TicketScanner ts = new TicketScanner(inputs);
            int output = ts.FindScanningErrorRate();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 
        public static void Day15Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day15A.txt");

            inputs = inputs[0].Split(',');
            int[] values = new int[inputs.Length];

            for (int i = 0; i < inputs.Length; i++)
            {
                values[i] = int.Parse(inputs[i]);
            }

            MemoryGame mg = new MemoryGame(values);
            int output = mg.GetNumberAt(30000000);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 234
        public static void Day15Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day15A.txt");

            inputs = inputs[0].Split(',');
            int[] values = new int[inputs.Length];

            for(int i = 0; i < inputs.Length; i++)
            {
                values[i] = int.Parse(inputs[i]);
            }

            MemoryGame mg = new MemoryGame(values);
            int output = mg.GetNumberAt(2020);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 4200656704538
        public static void Day14Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day14A.txt");

            BitmaskMemory bm = new BitmaskMemory(inputs);
            bm.RunV2();
            long output = bm.GetMemorySum();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 7440382076205
        public static void Day14Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day14A.txt");

            BitmaskMemory bm = new BitmaskMemory(inputs);
            bm.Run();
            long output = bm.GetMemorySum();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 
        public static void Day13Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day13A.txt");

            int startTime = Convert.ToInt32(inputs[0]);
            string[] schedule = inputs[1].Split(',');

            //long output = BusScheduler.FindEarliestSequence(schedule);
            ulong output = BusScheduler.FindSequentialTimestamp(schedule);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 5257
        public static void Day13Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day13A.txt");

            int startTime = Convert.ToInt32(inputs[0]);
            string[] schedule = inputs[1].Split(',');

            int output = BusScheduler.FindEarliestBusProduct(startTime, schedule);

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 51249
        public static void Day12Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day12A.txt");

            ShipNavigation sn = new ShipNavigation(0, 0, inputs, 10, 1);
            sn.NavigateWaypoint();
            int output = sn.GetManhattanDistance();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 757
        public static void Day12Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day12A.txt");

            ShipNavigation sn = new ShipNavigation(0, 0, inputs);
            sn.Navigate();
            int output = sn.GetManhattanDistance();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // ******** NOT SOLVED *******
        // Answer = 
        public static void Day11Part2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day11B.txt");

            SeatingSystem ss = new SeatingSystem(inputs);
            ss.RunGameOfLife(true);
            int output = ss.GetOccupiedCount();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        // Answer = 2178
        public static void Day11Part1()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day11A.txt");

            SeatingSystem ss = new SeatingSystem(inputs);
            ss.RunGameOfLife();
            int output = ss.GetOccupiedCount();

            Console.WriteLine("Output: ");
            Console.WriteLine(output);
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
