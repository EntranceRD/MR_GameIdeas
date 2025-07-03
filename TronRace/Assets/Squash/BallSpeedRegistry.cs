using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash 
{
    public class BallSpeedRegistry : MonoBehaviour
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
        public float[] speeds;
        #endregion

        #region PUBLIC METHODS
        public float GetSpeed(int level)
        {
            var index = Mathf.Clamp(level, 0, speeds.Length-1);
            return speeds[index];
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}