using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class ColorTransition
    {
        #region CONSTRUCTORS
        public ColorTransition()
        {
            time = new Timer() { Target = 0.2f };
            time.OnFinish = () => {
                transitioning = false;
            };
        }
        #endregion

        #region VARIABLES
        public Gradient gradient = new Gradient();

        public Timer time;
        public bool transitioning { get; private set; } = false;

        public Color color { get; private set; }
        #endregion

        #region PUBLIC METHODS
        public void Update(float deltaTime) {
            if (!transitioning) return;
            time.Tick(deltaTime);
            float percent = (time.Target - time.Remaining) / time.Target;
            color = gradient.Evaluate(percent);
        }
        public void Lerp()
        {
            if (transitioning) return;
            time.Restart();
            transitioning = true;
        }
        public void Restart() {
            color = gradient.Evaluate(0);
            transitioning = false;
        }
        #endregion
    }
}