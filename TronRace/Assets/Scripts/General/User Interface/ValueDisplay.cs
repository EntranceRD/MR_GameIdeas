using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public abstract class ValueDisplay : MonoBehaviour, IRestartable
    {
        public abstract void SetValue(float value);
        public abstract void Restart();
    }
}