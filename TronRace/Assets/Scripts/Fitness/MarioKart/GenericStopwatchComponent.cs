using Entrance;
using UnityEngine;

namespace Entrance
{
    public class GenericStopwatchComponent : MonoBehaviour
    {
        private void Awake()
        {
            if (stopwatch == null) stopwatch = new Stopwatch();
            stopwatch.OnFinish = () =>
            {
                OnFinish.Call();
            };
        }
        private void OnEnable()
        {
            Restart();
        }

        void Update()
        {
            if (!active) return;

            stopwatch.Tick(Time.deltaTime);
        }

        #region VARIABLES
        public Stopwatch stopwatch;
        public ButtonEvent OnFinish;
        private bool active = false;
        public bool resumeOnRestart = false;
        #endregion


        #region PUBLIC METHODS
        public void Restart()
        {
            stopwatch.Restart();
            Pause();
            if (resumeOnRestart)
            {
                Resume();
            }
        }
        public void Pause()
        {
            active = false;
        }
        public void Resume()
        {
            active = true;
        }
        public void Finish()
        {
            stopwatch.Tick(stopwatch.Target + 1);
        }
        public float SetFlag()
        {
            return stopwatch.currentTime;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {

        }
        #endregion
    }
}