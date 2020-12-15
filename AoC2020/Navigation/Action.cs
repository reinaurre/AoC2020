using System;

namespace AoC2020.Navigation
{
    public enum Direction
    {
        North,
        South,
        East,
        West,
        Left,
        Right,
        Forward,
    }

    public class Action
    {
        public Direction Direction { get; private set; }
        public int Distance { get; private set; }

        public Action(string input)
        {
            switch (input[0])
            {
                case 'N': Direction = Direction.North; break;
                case 'E': Direction = Direction.East; break;
                case 'S': Direction = Direction.South; break;
                case 'W': Direction = Direction.West; break;
                case 'L': Direction = Direction.Left; break;
                case 'F': Direction = Direction.Forward; break;
                case 'R': Direction = Direction.Right; break;
            }

            Distance = Convert.ToInt32(input.Substring(1));
        }
    }
}
