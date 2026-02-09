using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class WeightMapIndex
    {
        public int index;
        [Range(0,1)]
        public float weight = 1f;
    }
}