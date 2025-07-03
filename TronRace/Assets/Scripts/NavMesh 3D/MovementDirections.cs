using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Flags]
    public enum MovementDirections
    {
        None = 0,
        UP = 1 << 0, // 1
        DOWN = 1 << 1, // 2
        RIGHT = 1 << 2, // 4
        LEFT = 1 << 3  // 8
    }
}