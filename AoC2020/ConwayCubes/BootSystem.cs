using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace AoC2020.ConwayCubes
{
    public class BootSystem
    {
        private ConwayCube[,,] grid;
        private List<ConwayCube> cycleChanges;
        private int activeCount;
        private int gridSize;

        public BootSystem(string[] inputs)
        {
            gridSize = inputs[0].Length;
            grid = new ConwayCube[gridSize, gridSize, gridSize];
            cycleChanges = new List<ConwayCube>();
            activeCount = 0;

            InitializeGrid();
            ParseInputs(inputs);
        }

        public void RunBootSequence(int cycles)
        {
            for (int i = 0; i < cycles; i++)
            {
                RunCycle();
                InitializeGridExpansion();
            }
        }

        public int GetActiveCount()
        {
            return activeCount;
        }

        private void RunCycle()
        {
            for(int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    for (int z = 0; z < gridSize; z++)
                    {
                        CheckAdjacent(x, y, z);
                    }
                }
            }


            Dictionary<Coordinate, Symbol> coordinates2D = new Dictionary<Coordinate, Symbol>();
            List<Coordinate> coordinates = new List<Coordinate>();

            foreach (ConwayCube cube in cycleChanges)
            {
                grid[cube.Coordinate.X, cube.Coordinate.Y, cube.Coordinate.Z].IsActive = cube.IsActive;

                if (cube.Coordinate.Z == gridSize / 2)
                {
                    coordinates2D.Add(cube.Coordinate, cube.IsActive ? Symbol.Hash : Symbol.Dot);
                    coordinates.Add(new Coordinate(cube.Coordinate.X, cube.Coordinate.Y));
                }
            }

            MapMaker mm = new MapMaker(coordinates, Symbol.Box);
            mm.PopulateSeatMap(coordinates2D);
            mm.PrintMap();

            cycleChanges.Clear();
        }

        private void CheckAdjacent(int curX, int curY, int curZ)
        {
            int activeAdjacent = 0;

            for (int z = -1; z <= 1; z++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        if (x == 0 && y == 0 && z == 0)
                        {
                            continue;
                        }

                        if (curX + x >= 0 && curX+x < gridSize && curY + y >= 0 && curY + y < gridSize && curZ + z >= 0 && curZ + z < gridSize)
                        {
                            if (grid[curX + x, curY + y, curZ + z].IsActive)
                            {
                                activeAdjacent++;
                            }
                        }
                    }
                }
            }

            bool isCurrentActive = grid[curX, curY, curZ].IsActive;

            if (isCurrentActive && (activeAdjacent == 2 || activeAdjacent == 3))
            {
                // stay the same
            }
            else if (isCurrentActive)
            {
                cycleChanges.Add(new ConwayCube(false, curX, curY, curZ));
                activeCount--;
            }
            else if (!isCurrentActive && activeAdjacent == 3)
            {
                cycleChanges.Add(new ConwayCube(true, curX, curY, curZ));
                activeCount++;
            }
        }

        private void InitializeGrid()
        {
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    for (int z = 0; z < gridSize; z++)
                    {
                        grid[x, y, z] = new ConwayCube(false, x, y, z);
                    }
                }
            }
        }

        private void InitializeGridExpansion()
        {
            gridSize += 2;
            ConwayCube[,,] old = grid;
            grid = new ConwayCube[gridSize, gridSize, gridSize];

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    for (int z = 0; z < gridSize; z++)
                    {
                        if (x > 0 && x < gridSize - 1 && y > 0 && y < gridSize - 1 && z > 0 && z < gridSize - 1)
                        {
                            grid[x, y, z] = old[x - 1, y - 1, z - 1];
                        }
                        grid[x, y, z] = new ConwayCube(false, x, y, z);
                    }
                }
            }
        }

        private void ParseInputs(string[] inputs)
        {
            for(int y = 0; y < inputs.Length; y++)
            {
                for (int x = 0; x < inputs[y].Length; x++)
                {
                    if (inputs[y][x] == '.')
                    {
                        grid[x, y, 1].IsActive = false;
                    }
                    else if (inputs[y][x] == '#')
                    {
                        grid[x, y, 1].IsActive = true;
                        activeCount++;
                    }
                }
            }
        }
    }

    public class ConwayCube
    {
        public Coordinate3 Coordinate { get; private set; }
        public bool IsActive;

        public ConwayCube(bool state, int x, int y, int z)
        {
            Coordinate = new Coordinate3(x, y, z);
            IsActive = state;
        }
    }
}
