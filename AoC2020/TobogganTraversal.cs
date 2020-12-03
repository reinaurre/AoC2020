using System;
using System.Collections.Generic;
using System.Text;

namespace AoC2020
{
    public class TobogganTraversal
    {
        private int maxX;
        private int maxY;

        private int curX;
        private int curY;

        private string[] treeRows;

        public TobogganTraversal(string[] rows)
        {
            curX = 0;
            curY = 0;

            maxX = rows[0].Length - 1;
            maxY = rows.Length - 1;

            treeRows = rows;
        }

        public int CollisionDetector(int startX, int startY, int moveX, int moveY)
        {
            curX = startX;
            curY = startY;

            int hits = 0;

            while(curY <= maxY)
            {
                if(treeRows[curY][curX] == '#')
                {
                    hits++;
                }

                curX += moveX;
                if(curX > maxX)
                {
                    curX -= maxX+1;
                }

                curY += moveY;
            }

            return hits;
        }
    }
}
