using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class XMAScracker
    {
        private long[] workingSet;
        private int breakingIndex;

        public long FindRuleBreaker(int preambleLength, long[] input)
        {
            int backPointer = 0;
            workingSet = input;

            for(int i = preambleLength; i < workingSet.Length; i++)
            {
                if(!IsValid(i, backPointer))
                {
                    breakingIndex = i;
                    return workingSet[i];
                }

                backPointer++;
            }

            return -1;
        }

        public long FindWeakness()
        {
            for(int i = 0; i < breakingIndex; i++)
            {
                int j = i + 1;
                long sum = workingSet[i] + workingSet[j];

                long smallest = workingSet[i] < workingSet[j] ? workingSet[i] : workingSet[j];
                long largest = workingSet[i] > workingSet[j] ? workingSet[i] : workingSet[j];

                while (sum < workingSet[breakingIndex])
                {
                    j++;
                    sum += workingSet[j];

                    smallest = workingSet[j] < smallest ? workingSet[j] : smallest;
                    largest = workingSet[j] > largest ? workingSet[j] : largest;
                }

                if(sum == workingSet[breakingIndex])
                {
                    return smallest + largest;
                }
            }

            return -1;
        }

        private bool IsValid(int newNumIndex, int backPointer)
        {
            for(int i = backPointer; i < newNumIndex; i++)
            {
                for(int j = backPointer + 1; j < newNumIndex; j++)
                {
                    if(workingSet[i] + workingSet[j] == workingSet[newNumIndex])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
