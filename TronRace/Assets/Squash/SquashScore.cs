using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Squash 
{
    [System.Serializable]
    public class SquashScore
    {
        #region CONSTRUCTORS
        public SquashScore()
        {

        }
        #endregion

        #region VARIABLES
        public Image scoreDisplay;
        public GameObject scoreCanvas;
        public GameObject winRoom;
        public ButtonEvent OnReachMaxScore;
        private int score = 0;
        private int MaxScore = 10;
        #endregion

        #region PUBLIC METHODS
        public void Hide() { scoreCanvas.SetActive(false); }
        public void Show() { scoreCanvas.SetActive(true); }
        public void Restart() {
            ModifyScore(-MaxScore);
            winRoom.SetActive(false);
        }
        public void AddScore() {
            ModifyScore(1);
            if (score >= MaxScore) {
                OnReachMaxScore.Call();
                winRoom.SetActive(true);
            }
        }
        public void SetMaxScore(int max)
        {
            MaxScore = max;
            ModifyScore(0);
        }
        #endregion

        #region PRIVATE METHODS
        private void ModifyScore(int value)
        {
            score = Mathf.Clamp(score + value, 0, MaxScore);
            UpdateScoreDisplay();
        }
        private void UpdateScoreDisplay() {
            scoreDisplay.fillAmount = (float)score / (float)MaxScore;
        }
        #endregion
    }
}