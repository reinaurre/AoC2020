using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace AoC2020.Navigation
{
    public class ShipNavigation
    {
        private Coordinate startPosition;
        private Coordinate endPosition;
        private List<Coordinate> coordinates;
        private List<Action> actions;
        private Ship ship;

        public ShipNavigation(int startX, int startY, string[] inputs, int waypointX = 0, int waypointY = 0)
        {
            startPosition = new Coordinate(startX, startY);
            coordinates = new List<Coordinate>();
            coordinates.Add(startPosition);
            actions = new List<Action>();

            foreach (string input in inputs)
            {
                actions.Add(new Action(input));
            }

            ship = new Ship(startPosition, Direction.East, new Coordinate(waypointX, waypointY));
        }

        public void Navigate()
        {
            foreach(Action action in actions)
            {
                if (action.Direction == Direction.Left)
                {
                    ship.RotateShipLeft(action.Distance);
                }
                else if (action.Direction == Direction.Right)
                {
                    ship.RotateShipRight(action.Distance);
                }
                else if (action.Direction == Direction.Forward)
                {
                    ship.MoveShip(action.Distance, ship.CurrentHeading);
                }
                else
                {
                    ship.MoveShip(action.Distance, action.Direction);
                }
            }
        }

        public void NavigateWaypoint()
        {
            foreach (Action action in actions)
            {
                if (action.Direction == Direction.Left)
                {
                    ship.RotateWaypointLeft(action.Distance);
                }
                else if (action.Direction == Direction.Right)
                {
                    ship.RotateWaypointRight(action.Distance);
                }
                else if (action.Direction == Direction.Forward)
                {
                    ship.MoveShipToWaypoint(action.Distance);
                }
                else
                {
                    ship.MoveWaypoint(action.Distance, action.Direction);
                }

                Console.WriteLine($"X: {ship.CurrentPosition.X}, Y: {ship.CurrentPosition.Y}");
            }
        }

        public int GetManhattanDistance()
        {
            return Math.Abs(ship.CurrentPosition.X) + Math.Abs(ship.CurrentPosition.Y);
        }
    }
}
