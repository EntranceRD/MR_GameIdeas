using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class TimeSequence : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        [System.Serializable]
        public struct TimeSequenceStep {
            [Range(0, 600)] public float duration;
            public ButtonEvent Onfinish;
        }
        #region VARIABLES
        private TimeSequenceStep[] sequence;
        private int currentStep = 0;

        private Timer timer;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void MoveToNext()
        {
            if (currentStep + 1 >= sequence.Length) return;
            currentStep++;
            //timer.Target=sequence[]
        }
        #endregion
    }
}