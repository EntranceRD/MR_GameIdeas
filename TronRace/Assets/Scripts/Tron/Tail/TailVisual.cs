using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Tron
{
    [System.Serializable]
    public class TailVisual
    {
        #region CONSTRUCTORS
        public TailVisual()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ParticleSystem tailParticles;
        #endregion

        #region PUBLIC METHODS
        public void Restart(/*Vector3 position*/)
        {
            //transform.position = position;
            tailParticles.Play();
        }

        public void Stop()
        {
            tailParticles.Stop();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}