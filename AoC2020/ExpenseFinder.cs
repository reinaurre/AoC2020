using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public static class ExpenseFinder
    {
        public static int FindProduct(HashSet<int> expenses)
        {
            foreach(int num in expenses)
            {
                int target = 2020 - num;
                if (expenses.Contains(target))
                {
                    return num * target;
                }
            }

            return 0;
        }

        public static int FindJointProduct(HashSet<int> expenses)
        {
            foreach(int num in expenses)
            {
                int targetA = 2020 - num;

                foreach(int sub in expenses)
                {
                    if(sub != num)
                    {
                        int targetB = targetA - sub;
                        if (expenses.Contains(targetB))
                        {
                            return num * sub * targetB;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
