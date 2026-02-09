using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class SimpleSequence : MonoBehaviour, IRestartable
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ButtonEvent OnRestart;
        [SerializeField] private SequenceStep[] steps;
        private int currentStep = 0;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            //Debug.Log("Restarting");
            foreach (var step in steps)
                step.Restart();

            //Debug.Log("Restarting 1 ");
            OnRestart.Call();
            currentStep = 0;
            //Debug.Log("Restarting 2 ");
            steps[currentStep].Initialize();
            //Debug.Log(currentStep);
        }
        public void CheckCompletition() {
            //Debug.Log("current step state   " + steps[currentStep].isComplete());
            if (!steps[currentStep].isComplete()) return;

            //var temp = currentStep;
            steps[currentStep].OnFinish.Call();
            MoveStep();
            steps[currentStep].Initialize();
        }
        #endregion

        #region PRIVATE METHODS
        private void MoveStep()
        {
            //currentStep = Mathf.Min(currentStep + 1, steps.Length-1);
            currentStep = (++currentStep) % steps.Length;
            //++currentStep;
            //if (currentStep >= steps.Length) currentStep = 0;
        }
        #endregion
    }
}