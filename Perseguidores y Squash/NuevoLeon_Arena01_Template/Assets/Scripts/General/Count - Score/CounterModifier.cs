using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance
{
    [System.Serializable]
    public class CounterModifier
    {
        #region CONSTRUCTORS
        public CounterModifier()
        {

        }
        #endregion

        #region VARIABLES
        public AnimationCurve modifierEquation;
        private Counter _count;
        private int step = 0;
        #endregion

        #region PUBLIC METHODS
        public void Restart() { step = 0; }
        public void StepForward() { step++; }
        public void StepBackward() { step--; }
        public void SetStep(int value) { step = value; }
        public void SetCounter(Counter count) { _count = count; }
        public void AddToCount()
        {
            if (_count == null) { Debug.Log("_count is null"); return; }
            //Debug.Log("step to count is:  " + step);
            _count.Add((int)modifierEquation.Evaluate(step));
        }
        #endregion
    }
}