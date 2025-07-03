using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class VelocityLimitter : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            LimitVelocity();
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Rigidbody physics;
        [Range(0, 20), SerializeField] private float SpeedLimit = 5;
        #endregion

        #region PUBLIC METHODS
        public void LimitVelocity()
        {
            var speed = physics.velocity.magnitude;
            if (speed > SpeedLimit)
            {
                var dir = physics.velocity.normalized;
                physics.velocity = dir * SpeedLimit;
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