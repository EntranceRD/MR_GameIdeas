using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public interface ITimeCounter
    {
        Timer time { get; set; }
    }
}