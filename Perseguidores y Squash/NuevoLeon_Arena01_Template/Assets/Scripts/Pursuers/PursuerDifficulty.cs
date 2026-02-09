using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Pursuers
{
    public class PursuerDifficulty : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            if (paused) { return; }
            pursuerActivationTimer.Tick(Time.fixedDeltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private float[] pursuersTimers;
        [SerializeField] private float[] pursuersSpeeds;
        [SerializeField] private int[] pursuersPerLevel;
        private Timer pursuerActivationTimer;
        private int currentLevel = 0;
        [SerializeField] private PursuersController pursuers;
        private bool paused = false;
        #endregion

        #region PUBLIC METHODS
        public void Initialize() {
            if (pursuerActivationTimer == null)
            {
                pursuerActivationTimer = new Timer()
                {
                    OnFinish = () => { SetDifficulty(++currentLevel); }
                };
            }
        }
        public void Restart() { SetDifficulty(0); Resume(); }
        public void Pause() { paused = true; }
        public void Resume() { paused = false; }
        #endregion

        #region PRIVATE METHODS
        private void SetDifficulty(int level)
        {
            currentLevel = Mathf.Min(level, pursuersTimers.Length - 1);
            UpdateDifficultyVariables();
            pursuers.Activate(pursuersPerLevel[currentLevel]);
        }
        private void UpdateDifficultyVariables()
        {
            pursuerActivationTimer.Target = pursuersTimers[currentLevel];
            pursuerActivationTimer.Restart();
            pursuers.SetSpeedMultiplier(pursuersSpeeds[currentLevel]);            
        }
        #endregion
    }
}