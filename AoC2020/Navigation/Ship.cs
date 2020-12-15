using System;
using Utilities;

namespace AoC2020.Navigation
{
    public class Ship
    {
        public Coordinate CurrentPosition { get; private set; }
        public Direction CurrentHeading { get; private set; }
        public Coordinate WaypointPosition { get; private set; }

        public Ship(Coordinate coord, Direction direction, Coordinate waypointCoord = null)
        {
            CurrentPosition = coord;
            CurrentHeading = direction;
            WaypointPosition = waypointCoord;
        }

        public void MoveShip(int delta, Direction cardinalDirection)
        {
            switch (cardinalDirection)
            {
                case Direction.North: CurrentPosition = new Coordinate(CurrentPosition.X, CurrentPosition.Y + delta); break;
                case Direction.East: CurrentPosition = new Coordinate(CurrentPosition.X + delta, CurrentPosition.Y); break;
                case Direction.South: CurrentPosition = new Coordinate(CurrentPosition.X, CurrentPosition.Y - delta); break;
                case Direction.West: CurrentPosition = new Coordinate(CurrentPosition.X - delta, CurrentPosition.Y); break;
            }
        }

        public void MoveWaypoint(int delta, Direction cardinalDirection)
        {
            switch (cardinalDirection)
            {
                case Direction.North: WaypointPosition = new Coordinate(WaypointPosition.X, WaypointPosition.Y + delta); break;
                case Direction.East: WaypointPosition = new Coordinate(WaypointPosition.X + delta, WaypointPosition.Y); break;
                case Direction.South: WaypointPosition = new Coordinate(WaypointPosition.X, WaypointPosition.Y - delta); break;
                case Direction.West: WaypointPosition = new Coordinate(WaypointPosition.X - delta, WaypointPosition.Y); break;
            }

            Console.WriteLine($"waypoint position: {WaypointPosition.X},{WaypointPosition.Y}");
        }

        public void MoveShipToWaypoint(int times)
        {
            for (int i = 0; i < times; i++)
            {
                CurrentPosition = new Coordinate(CurrentPosition.X + WaypointPosition.X, CurrentPosition.Y + WaypointPosition.Y);
            }
        }

        public void RotateShipLeft(int degrees)
        {
            int repeatTimes = (int)MathF.Floor(degrees / 90);

            for (int i = 0; i < repeatTimes; i++)
            {
                switch (CurrentHeading)
                {
                    case Direction.North: CurrentHeading = Direction.West; break;
                    case Direction.East: CurrentHeading = Direction.North; break;
                    case Direction.South: CurrentHeading = Direction.East; break;
                    case Direction.West: CurrentHeading = Direction.South; break;
                    default: break;
                }
            }
        }

        public void RotateShipRight(int degrees)
        {
            int repeatTimes = (int)MathF.Floor(degrees / 90);

            for (int i = 0; i < repeatTimes; i++)
            {
                switch (CurrentHeading)
                {
                    case Direction.North: CurrentHeading = Direction.East; break;
                    case Direction.East: CurrentHeading = Direction.South; break;
                    case Direction.South: CurrentHeading = Direction.West; break;
                    case Direction.West: CurrentHeading = Direction.North; break;
                    default: break;
                }
            }
        }

        public void RotateWaypointLeft(int degrees)
        {
            int repeatTimes = (int)MathF.Floor(degrees / 90);

            for (int i = 0; i < repeatTimes; i++)
            {
                WaypointPosition = new Coordinate(WaypointPosition.Y * -1, WaypointPosition.X);
            }

            Console.WriteLine($"waypoint position: {WaypointPosition.X},{WaypointPosition.Y}");
        }

        public void RotateWaypointRight(int degrees)
        {
            int repeatTimes = (int)MathF.Floor(degrees / 90);

            for (int i = 0; i < repeatTimes; i++)
            {
                WaypointPosition = new Coordinate(WaypointPosition.Y, WaypointPosition.X * -1);
            }

            Console.WriteLine($"waypoint position: {WaypointPosition.X},{WaypointPosition.Y}");
        }
    }
}
