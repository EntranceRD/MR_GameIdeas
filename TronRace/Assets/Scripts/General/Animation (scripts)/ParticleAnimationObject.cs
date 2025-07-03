using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ParticleAnimationObject : PoolableObject
    {
        #region UNITY METHODS
        private void Awake()
        {
            OnActivation.AddAction(() => {
                particles.Play();
                animating = true;
            });
            OnRecycle.AddAction(() => {
                particles.Stop();
                animating = false;
            });
        }

        private void FixedUpdate()
        {
            if (!animating) return;
            if (!active) return;
            if (!particles.isPlaying)
                Recycle();
        }
        #endregion

        #region VARIABLES
        public ParticleSystem particles;
        private bool animating = false;
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