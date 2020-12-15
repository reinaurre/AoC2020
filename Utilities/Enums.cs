using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public enum Color
    {
        None = -1,
        Black = 0,
        White = 1
    }

    public enum Symbol
    {
        Empty = ' ',
        O = 'O',
        BigX = 'X',
        SmallX = '×',
        Box = '■',
        Dot = '.',
        Hash = '#',
        VLines = '║',
        HLines = '═',
        L = 'L',
    }

    public enum Tile
    {
        Empty = 0,
        Wall = 1,
        Block = 2,
        HPaddle = 3,
        Ball = 4
    }
}
