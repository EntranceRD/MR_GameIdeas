using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class PingPong_BallSpeedModifier : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var ball = other.GetComponent<PingPongBall>();
            if (ball != null) {
                ball.ModifySpeed(speedAddition);
            }
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField, Range(-1, 1)] private float speedAddition = 0.1f;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}