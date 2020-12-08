using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020.Computer
{
    public class BootCodeRunner
    {
        private int accumulator;
        private List<Operation> instructionSet;
        private List<int> problematicIndexes;

        public BootCodeRunner(string[] inputs)
        {
            instructionSet = new List<Operation>();
            problematicIndexes = new List<int>();
            accumulator = 0;

            ParseInstructions(inputs);
        }

        public void FixCorruption()
        {
            if (DetectLoop())
            {
                foreach(int index in problematicIndexes)
                {
                    switch (instructionSet[index].OpCode)
                    {
                        case OpCode.NoOp:
                            instructionSet[index].OpCode = OpCode.Jump;
                            if (!DetectLoop())
                            {
                                return;
                            }
                            instructionSet[index].OpCode = OpCode.NoOp;
                            break;

                        case OpCode.Jump:
                            instructionSet[index].OpCode = OpCode.NoOp;
                            if (!DetectLoop())
                            {
                                return;
                            }
                            instructionSet[index].OpCode = OpCode.Jump;
                            break;

                        default: break;
                    }
                }
            }
        }

        public int ExecuteCode()
        {
            int currentIndex = 0;

            while (currentIndex < instructionSet.Count)
            {
                switch (instructionSet[currentIndex].OpCode)
                {
                    case OpCode.NoOp: currentIndex++; break;

                    case OpCode.Accumulate:
                        accumulator += instructionSet[currentIndex].Value;
                        currentIndex++;
                        break;

                    case OpCode.Jump:
                        currentIndex += instructionSet[currentIndex].Value;
                        break;
                }
            }

            return accumulator;
        }

        public bool DetectLoop()
        {
            HashSet<int> usedIndexes = new HashSet<int>();
            int currentIndex = 0;

            while (!usedIndexes.Contains(currentIndex) && currentIndex < instructionSet.Count)
            {
                usedIndexes.Add(currentIndex);

                switch (instructionSet[currentIndex].OpCode)
                {
                    case OpCode.NoOp: currentIndex++; break;

                    case OpCode.Accumulate:
                        currentIndex++;
                        break;

                    case OpCode.Jump:
                        currentIndex += instructionSet[currentIndex].Value;
                        break;
                }
            }

            return currentIndex != instructionSet.Count;
        }

        public int ExecuteCode_BreakOnLoop()
        {
            HashSet<int> usedIndexes = new HashSet<int>();
            int currentIndex = 0;

            while (!usedIndexes.Contains(currentIndex))
            {
                usedIndexes.Add(currentIndex);

                switch (instructionSet[currentIndex].OpCode)
                {
                    case OpCode.NoOp:
                        currentIndex++; 
                        break;

                    case OpCode.Accumulate: 
                        accumulator += instructionSet[currentIndex].Value;
                        currentIndex++;
                        break;

                    case OpCode.Jump:
                        currentIndex += instructionSet[currentIndex].Value;
                        break;
                }
            }

            return accumulator;
        }

        private void ParseInstructions(string[] inputs)
        {
            int counter = 0;

            foreach(string input in inputs)
            {
                string operation = input.Substring(0, 3);
                char sign = input[4];
                int value = Convert.ToInt32(input.Substring(5));

                if(sign == '-')
                {
                    value *= -1;
                }

                switch (operation)
                {
                    case "nop":
                        problematicIndexes.Add(counter);
                        instructionSet.Add(new Operation(counter, OpCode.NoOp, value)); 
                        break;

                    case "acc": 
                        instructionSet.Add(new Operation(counter, OpCode.Accumulate, value)); 
                        break;

                    case "jmp":
                        problematicIndexes.Add(counter);
                        instructionSet.Add(new Operation(counter, OpCode.Jump, value)); break;

                    default: break;
                }

                counter++;
            }
        }
    }

    public class Operation
    {
        public int Index;
        public OpCode OpCode;
        public int Value;

        public Operation(int index, OpCode opCode, int value)
        {
            Index = index;
            OpCode = opCode;
            Value = value;
        }
    }

    public enum OpCode
    {
        NoOp,
        Accumulate,
        Jump
    }
}
