using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class TimerTextDisplay : ValueDisplay
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            if (TimerObject != null) { 
            timeCounter = TimerObject.GetComponent<ITimeCounter>();
            }
        }
        private void Update()
        {
            if (timeCounter == null) return;
            if (integers)
            {
                SetValue((int)timeCounter.time.Remaining);
            }
            else { 
                SetValue(timeCounter.time.Remaining);
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private GameObject TimerObject;
        [SerializeField] private bool integers=false;
        [SerializeField] private TMPro.TMP_Text[] displays;
        private ITimeCounter timeCounter;
        #endregion

        #region PUBLIC METHODS
        public override void SetValue(float value)
        {
            var seconds = (int)value;
            var millis = (value - seconds)*100;

            var text = string.Format("{0:00}:{1:00}", seconds, millis);

            foreach (var display in displays)
                display.text = text;
        }
        public override void Restart()
        {
            foreach (var display in displays)
                display.text = string.Empty;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}