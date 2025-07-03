using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Entrance
{
    [Serializable]
    public class NTHConfig
    {
        public int Port;
        public string IP;
        public SurfaceIDs[] surfaces;
        public int FrameRate = 40;
    }
}