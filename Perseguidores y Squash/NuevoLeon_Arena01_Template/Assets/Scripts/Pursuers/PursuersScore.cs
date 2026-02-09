using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Pursuers
{
    public class PursuersScore : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            if (paused) { return; }
            scoreRateTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        public int score { get; private set; }
        [SerializeField,Range(0,100)] private int scoreRate;
        [SerializeField] private Timer scoreRateTimer;
        [SerializeField] private TMPro.TMP_Text[] scoreDisplays;
        private bool paused = false;
        #endregion

        #region PUBLIC METHODS
        public void Initialize()
        {
            scoreRateTimer.OnFinish = () => {
                scoreRateTimer.Restart();
                ModifyScore(scoreRate);
            };
            scoreRateTimer.Restart();
        }
        public void Restart() {
            Resume();
            score = 0;
            scoreRateTimer.Restart();
            DisplayScore();
        }
        public void Pause() { paused = true; }
        public void Resume() { paused = false; }
        public void ModifyScore(int amount) {
            score = Mathf.Max(score+ amount, 0);
            DisplayScore();
        }
        #endregion

        #region PRIVATE METHODS
        private void DisplayScore()
        {
            var text = string.Format("{0:00}", (int)score);
            for (int i = 0; i < scoreDisplays.Length; ++i)
                if (scoreDisplays[i] != null)
                    scoreDisplays[i].text = text;
        }
        #endregion
    }
}