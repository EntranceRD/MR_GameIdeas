using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Hokuyo
{
    [System.Serializable]
    public struct HokuyoResponse
    {
        public HokuyoDataResponse[] data;
    }
    [System.Serializable]
    public struct HokuyoDataResponse
    {
        public HokuyoDataResponse(Vector3 direction, params Vector3[] points)
        {
            Direction = direction;
            InteractionPoints = points;
        }
        public Vector3 Direction; //pivot
        public Vector3[] InteractionPoints; //rotatedPoints
    }
}