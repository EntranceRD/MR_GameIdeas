using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Score : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            modifier.SetCounter(score);
        }
        #endregion

        #region VARIABLES
        public Counter score;
        public CounterModifier modifier;
        public TMPro.TMP_Text[] scoreDisplays;
        #endregion

        #region PUBLIC METHODS
        public void SetModifierEquation(AnimationCurve equation)
        {
            modifier.modifierEquation = equation;
        }
        public void Restart() {
            score.Restart();
            modifier.Restart();
            UpdateDisplays();
        }
        public void AddScore() {
            modifier.AddToCount();
            UpdateDisplays();
        }
        public void MoveEquationX() {
            modifier.StepForward();
        }
        public void BackEquationX()
        {
            modifier.StepBackward();
        }
        public void SetStep(int index) {
            modifier.SetStep(index);
        }
        public void HideDisplays() {
            foreach (var display in scoreDisplays)
                display.text = "";
        }
        #endregion

        #region PRIVATE METHODS
        private void UpdateDisplays()
        {
            //int value = score;
            //var text = ((int)score).ToString();
            var text = string.Format("{0:00}", (int)score);
            for (int i = 0; i < scoreDisplays.Length; ++i)
                if(scoreDisplays[i]!=null)
                scoreDisplays[i].text = text;
        }
        #endregion
    }
}