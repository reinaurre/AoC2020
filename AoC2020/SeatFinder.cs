using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AoC2020
{
    public class SeatFinder
    {
        // 0-127 rows, 0-7 columns
        // first 7 = F/B, last 3 = R/L
        // seat ID = row * 8 + column

        private int passIndex;
        private List<int> seatIds;

        public int FindHighestID(string[] boardingPasses, int maxColumns, int maxRows)
        {
            int highestId = int.MinValue;
            seatIds = new List<int>();

            foreach(string pass in boardingPasses)
            {
                passIndex = 0;
                int row = DivideRows(pass, 0, maxColumns);
                int column = DivideColumns(pass, 0, maxRows);

                int passId = row * (maxRows+1) + column;
                seatIds.Add(passId);

                highestId = passId > highestId ? passId : highestId;
            }

            return highestId;
        }

        public int FindMySeat()
        {
            if(seatIds == null)
            {
                Console.WriteLine("Call FindHighestID first to build the seat list");
                return -1;
            }

            seatIds.Sort();
            int target = seatIds[0];

            for (int i = 0; i < seatIds.Count - 1; i++)
            {
                if (seatIds[i] != target && (seatIds[i - 1] == target - 1 || seatIds[i + 1] == target + 1))
                {
                    return target;
                }

                target++;
            }

            return -1;
        }

        private int DivideRows(string pass, int low, int high)
        {
            if(pass[passIndex] == 'L' || pass[passIndex] == 'R')
            {
                return low == high ? low : -1;
            }

            if(pass[passIndex] == 'F')
            {
                passIndex++;
                return DivideRows(pass, low, (int)MathF.Floor((high + low) / 2f));
            }
            else if(pass[passIndex] == 'B')
            {
                passIndex++;
                return DivideRows(pass, (int)MathF.Ceiling((low + high) / 2f), high);
            }

            return 0;
        }

        private int DivideColumns(string pass, int low, int high)
        {
            if(passIndex == pass.Length)
            {
                return low == high ? low : -1;
            }

            if(pass[passIndex] == 'L')
            {
                passIndex++;
                return DivideColumns(pass, low, (int)MathF.Floor((high + low) / 2f));
            }
            else if(pass[passIndex] == 'R')
            {
                passIndex++;
                return DivideColumns(pass, (int)MathF.Ceiling((low + high) / 2f), high);
            }

            return 0;
        }
    }
}
