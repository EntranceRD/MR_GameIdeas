using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Tron
{
    public struct InstanceInstruction
    {
        public InstanceInstruction(Vector3 position, float time, System.Action onFinish)
        {
            this.position = position;
            instanceTimer = new Timer() { Target = time, OnFinish = onFinish };
            instanceTimer.Restart();
        }
        public Vector3 position;
        public Timer instanceTimer;
    }
}