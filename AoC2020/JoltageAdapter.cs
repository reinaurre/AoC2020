using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class JoltageAdapter
    {
        private Dictionary<int, long> joltageDiffs;
        private int[] adapters;

        public JoltageAdapter(List<int> inputs)
        {
            List<int> adapterList = inputs;
            adapterList.Add(0);
            adapterList.Sort();
            adapterList.Add(adapterList[adapterList.Count - 1] + 3);
            adapters = adapterList.ToArray();
        }

        public int DiffProduct(int maxDiff)
        {
            joltageDiffs = new Dictionary<int, long>();
            for (int i = 0; i <= maxDiff; i++)
            {
                joltageDiffs.Add(i, 0);
            }

            SumDiffs();
            return (int)(joltageDiffs[1] * joltageDiffs[3]);
        }

        private void SumDiffs()
        {
            int prev = 0;
            for(int i = 0; i < adapters.Length; i++)
            {
                joltageDiffs[adapters[i] - prev]++;
                prev = adapters[i];
            }
        }

        public long CountCombinations()
        {
            joltageDiffs = new Dictionary<int, long>();
            return CombinationCount(adapters, 0);
        }

        private long CombinationCount(int[] adapters, int start)
        {
            if (joltageDiffs.ContainsKey(start))
            {
                return joltageDiffs[start];
            }

            long options = 0;
            for (int i = start + 1; i < adapters.Length && adapters[i] - adapters[start] <= 3; i++)
            {
                options += CombinationCount(adapters, i);
            }

            options = options == 0 ? 1 : options;

            joltageDiffs.Add(start, options);

            return options;
        }
    }
}
