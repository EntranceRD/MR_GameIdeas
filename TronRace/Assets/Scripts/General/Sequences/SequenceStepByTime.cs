using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class SequenceStepByTime:SequenceStep
    {
        #region CONSTRUCTORS
        public SequenceStepByTime()
        {
            minimumTime = new Timer() {
                Target = 1f,
                OnFinish = () => { timeCompleted = true; OnFinishTime.Call(); }
            };
        }
        #endregion

        #region UNITY METHODS
        private void Start()
        {
            minimumTime.OnFinish += () => { sequence.CheckCompletition(); };
        }
        private void Update()
        {
            //if (!metButtonRequirements) return;
            if (timeCompleted) return;
            minimumTime.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        public Timer minimumTime;
        private bool timeCompleted = false;
        public SimpleSequence sequence;
        public ButtonEvent OnFinishTime;
        private bool metButtonRequirements = false;
        #endregion

        #region PUBLIC METHODS
        public void CheckTimeRequirements() {
            //if (!base.isComplete()) return;
            //minimumTime.Restart();
            //metButtonRequirements = true;
        }
        public override bool isComplete()
        {
            //return metButtonRequirements && timeCompleted;
            if (!timeCompleted) return false;
            return base.isComplete();
        }
        public override void Restart() {
            base.Restart();
            minimumTime.Restart();
            timeCompleted = false;
            //metButtonRequirements = false;
        }
        public override void Initialize() {
            base.Initialize();
            minimumTime.Restart();
            timeCompleted = false;
        }
        #endregion
    }
}