using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace AoC2020.Seating
{
    public class Seat
    {
        public Coordinate Coordinate { get; private set; }
        public List<Coordinate> AdjacentSeats { get; private set; }

        public Seat(int x, int y)
        {
            Coordinate = new Coordinate(x, y);
            AdjacentSeats = new List<Coordinate>();
        }
    }
}
