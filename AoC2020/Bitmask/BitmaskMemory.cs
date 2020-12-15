using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AoC2020.NewFolder
{
    public class BitmaskMemory
    {
        private Dictionary<long, long> memory;
        private string mask;
        private List<KeyValuePair<long, string>> actions;

        public BitmaskMemory(string[] inputs)
        {
            mask = inputs[0].Substring(7); // remove "mask = "
            memory = new Dictionary<long, long>();
            actions = new List<KeyValuePair<long, string>>();

            int memActionCount = 0;

            for (int i = 1; i < inputs.Length; i++)
            {
                if (inputs[i].Contains("mask = "))
                {
                    actions.Add(new KeyValuePair<long, string>(-1, inputs[i].Substring(7)));
                }
                else
                {
                    memActionCount++;
                    var matches = Regex.Matches(inputs[i], @"[0-9]+");
                    actions.Add(new KeyValuePair<long, string>(long.Parse(matches[0].Value), matches[1].Value));
                }
            }
        }

        public void Run()
        {
            foreach(KeyValuePair<long, string> kvp in actions)
            {
                if (kvp.Key == -1)
                {
                    mask = kvp.Value;
                }
                else
                {
                    long converted = long.Parse(kvp.Value);

                    char[] binary = ConvertToBinaryString(converted).ToCharArray();

                    for (int i = 0; i < binary.Length; i++)
                    {
                        if (binary[i] != mask[i] && mask[i] != 'X')
                        {
                            binary[i] = mask[i];
                        }
                    }

                    converted = Convert.ToInt64(new string(binary), 2);
                    memory[kvp.Key] = converted;
                }
            }
        }

        public void RunV2()
        {
            foreach(KeyValuePair<long, string> kvp in actions)
            {
                if (kvp.Key == -1)
                {
                    mask = kvp.Value;
                }
                else
                {
                    char[] binaryAddress = ConvertToBinaryString(kvp.Key).ToCharArray();
                    RecursiveWriteToMemory(0, binaryAddress, Convert.ToInt64(kvp.Value));
                }
            }
        }

        private void RecursiveWriteToMemory(int index, char[] binaryAddress, long valueToWrite)
        {
            if (index == binaryAddress.Length)
            {
                long converted = Convert.ToInt64(new string(binaryAddress), 2);
                memory[converted] = valueToWrite;
                return;
            }

            if (mask[index] == 'X')
            {
                char[] new0 = new char[binaryAddress.Length];
                binaryAddress.CopyTo(new0, 0);
                char[] new1 = new char[binaryAddress.Length];
                binaryAddress.CopyTo(new1, 0);
                new0[index] = '0';
                new1[index] = '1';

                RecursiveWriteToMemory(index + 1, new0, valueToWrite);
                RecursiveWriteToMemory(index + 1, new1, valueToWrite);
            }
            else if (mask[index] == '1')
            {
                binaryAddress[index] = '1';
                RecursiveWriteToMemory(index + 1, binaryAddress, valueToWrite);
            }
            else
            {
                RecursiveWriteToMemory(index + 1, binaryAddress, valueToWrite);
            }
        }

        public long GetMemorySum()
        {
            long sum = 0;
            foreach(KeyValuePair<long, long> kvp in memory)
            {
                sum += kvp.Value;
            }

            return sum;
        }

        private string ConvertToBinaryString(long input)
        {
            string binary = Convert.ToString(input, 2);

            if (binary.Length < mask.Length)
            {
                string prepend = string.Empty;

                for (int i = 0; i < mask.Length - binary.Length; i++)
                {
                    prepend += "0";
                }

                binary = prepend + binary;
            }

            return binary;
        }
    }
}
