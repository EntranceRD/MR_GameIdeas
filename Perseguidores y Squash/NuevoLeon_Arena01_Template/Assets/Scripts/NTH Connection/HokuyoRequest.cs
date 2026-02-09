using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Hokuyo
{
    [System.Serializable]
    public class HokuyoRequest
    {
        public HokuyoRequest(SurfaceIDs[] _surfaces, string info ="") { surfaces = _surfaces; AdditionalInfo = info; }
        public SurfaceIDs[] surfaces;
        public string AdditionalInfo;
    }
}