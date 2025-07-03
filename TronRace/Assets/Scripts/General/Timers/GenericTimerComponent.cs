using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class GenericTimerComponent : MonoBehaviour, ITimeCounter
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (timer == null) timer = new Timer();
            timer.OnFinish = () => { OnFinish.Call(); };
        }
        private void OnEnable()
        {
            Restart();
        }

        private void Update()
        {
            if (!active) return;
            timer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        public Timer time { get { return timer; } set { } }
        public Timer timer;
        public ButtonEvent OnFinish;
        private bool active = false;
        public bool resumeOnRestart = false;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            timer.Restart();
            Pause();
            if (resumeOnRestart) {
                //por que estaba comentado???
                Resume();
            }
        }
        public void Pause() {
            active = false;
        }
        public void Resume()
        {
            active = true;
        }
        public void Finish() {
            timer.Tick(timer.Target + 1);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}