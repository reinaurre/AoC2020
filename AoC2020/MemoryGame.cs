using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class MemoryGame
    {
        private Dictionary<int, List<int>> History;
        private int CurrentTurn;
        private int MostRecent;

        public MemoryGame(int[] inputs)
        {
            History = new Dictionary<int, List<int>>();

            for (int i = 0; i < inputs.Length; i++)
            {
                History.Add(inputs[i], new List<int>() { i + 1 });
                MostRecent = inputs[i];
            }

            CurrentTurn = inputs.Length+1;
        }

        public int GetNumberAt(int targetTurn)
        {
            while (CurrentTurn <= targetTurn)
            {
                MostRecent = DoTurn(MostRecent);

                CurrentTurn++;
            }

            return MostRecent;
        }

        private int DoTurn(int mostRecent)
        {
            if (History.ContainsKey(mostRecent))
            {
                if (History[mostRecent].Count == 1)
                {
                    if (History.ContainsKey(0))
                    {
                        History[0].Add(CurrentTurn);
                    }
                    else
                    {
                        History.Add(0, new List<int>() { CurrentTurn });
                    }

                    return 0;
                }
                else
                {
                    int length = History[mostRecent].Count;
                    int diff = History[mostRecent][length - 1] - History[mostRecent][length - 2];

                    if (History.ContainsKey(diff))
                    {
                        History[diff].Add(CurrentTurn);
                    }
                    else
                    {
                        History.Add(diff, new List<int>() { CurrentTurn });
                    }

                    return diff;
                }
            }
            else
            {
                History.Add(mostRecent, new List<int>() { CurrentTurn });
                return mostRecent;
            }
        }
    }
}
