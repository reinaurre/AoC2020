using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace AoC2020.Seating
{
    public class SeatingSystem
    {
        private Dictionary<Seat, Symbol> seatingGrid;
        private List<Symbol> symbolTracker;
        private int maxX;
        private int maxY;

        public SeatingSystem(string[] inputs)
        {
            maxX = inputs[0].Length - 1;
            maxY = inputs.Length - 1;
            seatingGrid = new Dictionary<Seat, Symbol>();
            symbolTracker = new List<Symbol>();

            BuildSeatingGrid(inputs);
        }

        public int GetOccupiedCount()
        {
            int count = 0;

            foreach(KeyValuePair<Seat, Symbol> kvp in seatingGrid)
            {
                if (kvp.Value == Symbol.Hash)
                {
                    count++;
                }
            }

            return count;
        }

        public void RunGameOfLife(bool LOSrules = false)
        {
            List<Symbol> oldValues = new List<Symbol>();
            List<Symbol> newValues = GameOfLifeRound(LOSrules);

            while (!symbolTracker.SequenceEqual(newValues))
            {
                oldValues = symbolTracker;
                symbolTracker = newValues;
                newValues = GameOfLifeRound(LOSrules);

                Dictionary<Coordinate, Symbol> coordList = new Dictionary<Coordinate, Symbol>();
                foreach (KeyValuePair<Seat, Symbol> kvp in seatingGrid)
                {
                    coordList.Add(kvp.Key.Coordinate, kvp.Value);
                }

                MapMaker mm = new MapMaker(coordList.Keys.ToList(), Symbol.Dot);
                mm.PopulateSeatMap(coordList);
                mm.PrintLiveUpdates();

                if (oldValues.SequenceEqual(newValues))
                {
                    throw new Exception();
                }
            }
        }

        private List<Symbol> GameOfLifeRound(bool LOSrules = false)
        {
            List<Symbol> newValues = new List<Symbol>();
            List<KeyValuePair<Seat, Symbol>> updateList = new List<KeyValuePair<Seat, Symbol>>();

            foreach (KeyValuePair<Seat, Symbol> kvp in seatingGrid)
            {
                if (kvp.Value == Symbol.Dot)
                {
                    newValues.Add(Symbol.Dot);
                    continue;
                }

                Symbol newSymbol = LOSrules
                    ? CheckNeighborsLOS(kvp.Key)
                    : CheckNeighbors(kvp.Key.Coordinate.Y, kvp.Key.Coordinate.X);

                if (newSymbol != Symbol.Box)
                {
                    KeyValuePair<Seat, Symbol> update = new KeyValuePair<Seat, Symbol>(kvp.Key, newSymbol == Symbol.Box ? kvp.Value : newSymbol);
                    updateList.Add(update);
                    newValues.Add(update.Value);
                }
                else
                {
                    newValues.Add(kvp.Value);
                }
            }

            foreach (KeyValuePair<Seat, Symbol> kvp in updateList)
            {
                seatingGrid[kvp.Key] = kvp.Value;
            }

            return newValues;
        }

        private Symbol CheckNeighbors(int row, int column)
        {
            int activeNeighbors = 0;

            for (int c = -1; c <= 1; c++)
            {
                for (int r = -1; r <= 1; r++)
                {
                    if (row + r >= 0 && row + r <= maxY && column + c >= 0 && column + c <= maxX && !(r == 0 && c == 0))
                    {
                        if(seatingGrid.First(x => x.Key.Coordinate.X == column + c && x.Key.Coordinate.Y == row + r).Value == Symbol.Hash)
                        {
                            activeNeighbors++;
                        }
                    }
                }
            }

            if (activeNeighbors >= 4)
            {
                return Symbol.L;
            }
            else if (activeNeighbors == 0)
            {
                return Symbol.Hash;
            }

            return Symbol.Box;
        }

        private Symbol CheckNeighborsLOS(Seat current)
        {
            int activeNeighbors = 0;

            foreach (Coordinate coord in current.AdjacentSeats)
            {
                if (seatingGrid.First(x => x.Key.Coordinate.X == coord.X && x.Key.Coordinate.Y == coord.Y).Value == Symbol.Hash)
                {
                    activeNeighbors++;
                }
            }

            if (activeNeighbors >= 5)
            {
                return Symbol.L;
            }
            else if (activeNeighbors == 0)
            {
                return Symbol.Hash;
            }

            return Symbol.Box;
        }

        private void BuildSeatingGrid(string[] inputs)
        {
            int rowPosition = 0;
            foreach (string row in inputs)
            {
                for (int seat = 0; seat < row.Length; seat++)
                {
                    switch (row[seat])
                    {
                        case 'L':
                            seatingGrid.Add(new Seat(seat, rowPosition), Symbol.L);
                            symbolTracker.Add(Symbol.L);
                            break;
                        case '.':
                            seatingGrid.Add(new Seat(seat, rowPosition), Symbol.Dot);
                            symbolTracker.Add(Symbol.Dot);
                            break;
                        default: break;
                    }
                }
                rowPosition++;
            }

            AssignAdjacentSeats();
        }

        private void AssignAdjacentSeats()
        {
            foreach (KeyValuePair<Seat, Symbol> kvp in seatingGrid)
            {
                if (kvp.Value == Symbol.Dot)
                {
                    continue;
                }

                FindNeighborsLOS(kvp.Key);
            }
        }

        private void FindNeighborsLOS(Seat current)
        {
            for (int c = -1; c <= 1; c++)
            {
                for (int r = -1; r <= 1; r++)
                {
                    if (current.Coordinate.Y + r >= 0 && current.Coordinate.Y + r <= maxY && current.Coordinate.X + c >= 0 && current.Coordinate.X + c <= maxX && !(r == 0 && c == 0))
                    {
                        Seat adjacent = FindLOSRecursively(new Seat(current.Coordinate.X + c, current.Coordinate.Y + r), c, r);

                        if (adjacent != null)
                        {
                            current.AdjacentSeats.Add(adjacent.Coordinate);
                        }
                    }
                }
            }
        }

        private Seat FindLOSRecursively(Seat root, int quadSignX, int quadSignY)
        {
            Symbol currentValue = seatingGrid.FirstOrDefault(x => x.Key.Coordinate.X == root.Coordinate.X && x.Key.Coordinate.Y == root.Coordinate.Y).Value;

            if (currentValue == Symbol.Hash || currentValue == Symbol.L)
            {
                return root;
            }

            if (root.Coordinate.X + quadSignX >= 0 && root.Coordinate.Y + quadSignY >= 0 && root.Coordinate.X + quadSignX <= maxX && root.Coordinate.Y +quadSignY <= maxY)
            {
                return this.FindLOSRecursively(new Seat(root.Coordinate.X + quadSignX, root.Coordinate.Y - quadSignY), quadSignX, quadSignY);
            }

            //// East
            //if (quadSignX > 0 && root.Coordinate.X + 1 < maxX)
            //{
            //    for (int i = root.Coordinate.X + 1; i < maxX; i++)
            //    {
            //        currentValue = seatingGrid.First(x => x.Key.Coordinate.X == i && x.Key.Coordinate.Y == root.Coordinate.Y).Value;
            //        if (currentValue == Symbol.Hash || currentValue == Symbol.L)
            //        {
            //            return root;
            //        }
            //    }
            //}

            //// West
            //if (quadSignX < 0 && root.Coordinate.X - 1 >= 0)
            //{
            //    for (int i = root.Coordinate.X - 1; i >= 0; i--)
            //    {
            //        currentValue = seatingGrid.First(x => x.Key.Coordinate.X == i && x.Key.Coordinate.Y == root.Coordinate.Y).Value;
            //        if (currentValue == Symbol.Hash || currentValue == Symbol.L)
            //        {
            //            return root;
            //        }
            //    }
            //}

            //// North
            //if (quadSignY < 0 && root.Coordinate.Y - 1 >= 0)
            //{
            //    for (int i = root.Coordinate.Y - 1; i >= 0; i--)
            //    {
            //        currentValue = seatingGrid.First(x => x.Key.Coordinate.X == i && x.Key.Coordinate.Y == root.Coordinate.Y).Value;
            //        if (currentValue == Symbol.Hash || currentValue == Symbol.L)
            //        {
            //            return root;
            //        }
            //    }
            //}

            //// South
            //if (quadSignY > 0 && root.Coordinate.Y + 1 < maxY)
            //{
            //    for (int i = root.Coordinate.Y + 1; i < maxY; i++)
            //    {
            //        currentValue = seatingGrid.First(x => x.Key.Coordinate.X == i && x.Key.Coordinate.Y == root.Coordinate.Y).Value;
            //        if (currentValue == Symbol.Hash || currentValue == Symbol.L)
            //        {
            //            return root;
            //        }
            //    }
            //}

            //// NE
            //if (quadSignX > 0 && quadSignY < 0 && root.Coordinate.X + 1 < maxX && root.Coordinate.Y - 1 >= 0)
            //{
            //    return this.FindLOSRecursively(new Seat(root.Coordinate.X + 1, root.Coordinate.Y - 1), quadSignX, quadSignY);
            //}
            //// SE
            //else if (quadSignX > 0 && quadSignY > 0 && root.Coordinate.X + 1 < maxX && root.Coordinate.Y + 1 < maxY)
            //{
            //    return this.FindLOSRecursively(new Seat(root.Coordinate.X + 1, root.Coordinate.Y + 1), quadSignX, quadSignY);
            //}
            //// SW
            //else if (quadSignX < 0 && quadSignY > 0 && root.Coordinate.X - 1 >= 0 && root.Coordinate.Y + 1 < maxY)
            //{
            //    return this.FindLOSRecursively(new Seat(root.Coordinate.X - 1, root.Coordinate.Y + 1), quadSignX, quadSignY);
            //}
            //// NW
            //else if (quadSignX < 0 && quadSignY < 0 && root.Coordinate.X - 1 >= 0 && root.Coordinate.Y - 1 >= 0)
            //{
            //    return this.FindLOSRecursively(new Seat(root.Coordinate.X - 1, root.Coordinate.Y - 1), quadSignX, quadSignY);
            //}

            return null;
        }
    }
}
