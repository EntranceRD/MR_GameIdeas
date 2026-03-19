using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Entrance
{
    public class TimerTextDisplay : ValueDisplay
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            if (TimerObject != null)
            {
                timeCounter = TimerObject.GetComponent<ITimeCounter>();
            }
        }
        private void Update()
        {
            if (timeCounter == null) return;
            //if (integers)
            //{
            //    SetValue((int)timeCounter.time.Remaining);
            //}
            //else { 
            //    SetValue(timeCounter.time.Remaining);
            //}
            SetValue(timeCounter.time.Remaining);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private GameObject TimerObject;
        [SerializeField] private bool useMinutes = false;
        [SerializeField] private bool useMillis = false;
        [SerializeField] private TMP_Text[] _displays;
        private ITimeCounter timeCounter;
        #endregion

        #region PUBLIC METHODS
        public override void SetValue(float value)
        {
            var seconds = (int)value;
            var minutes = seconds / 60;
            var millis = (value - seconds) * 100;

            string minutes_text = string.Format("{0:00}", minutes);
            string seconds_text = string.Format("{0:00}", useMinutes ? seconds - (minutes * 60) : seconds);
            string millis_text = string.Format("{0:00}", millis);
            string text = (useMinutes ? $"{minutes_text}:" : string.Empty) + $"{seconds_text}" + (useMillis ? $":{millis_text}" : string.Empty);

            foreach (var display in _displays)
                display.text = text;
        }
        public override void Restart()
        {
            throw new System.NotImplementedException();
        }

        public virtual void SetDisplays(TMP_Text[] displays)
        {
            _displays = displays;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {

        }
        #endregion
    }
}