using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dart
{
    public enum Direction : byte
    {
        None =      0,
        Left =      0b1000,
        Down =      0b0100,
        Up =        0b0010,
        Right =     0b0001,

        DownLeft =  Down | Left,
        DownRight = Down | Right,
        UpLeft =    Up | Left,
        UpRight =   Up | Right,

        Vertical = Up | Down,
        Horizontal = Left | Right
    }
}
