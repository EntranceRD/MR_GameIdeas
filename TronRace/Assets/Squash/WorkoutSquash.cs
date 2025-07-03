using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Squash;

namespace Entrance 
{
    public class WorkoutSquash : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            foreach (var ball in balls) {
                ball.OnCaptured.AddAction(() => {
                    //ball.gameArea
                    //var speed = speeds.GetSpeed()
                    //ball.SetSpeed();
                });
            }
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private SquashBall[] balls;
        [SerializeField] private BallSpeedRegistry speeds;
        #endregion

        #region PUBLIC METHODS
        public void Stop()
        {
            foreach (var ball in balls) {
                ball.SetSpeed(0);
                ball.Restart();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}