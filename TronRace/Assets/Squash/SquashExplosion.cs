using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash 
{
    public class SquashExplosion : MonoBehaviour
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
        [SerializeField] private ParticleSystem explosion;
        #endregion

        #region PUBLIC METHODS
        public void Activate(Transform position)
        {
            transform.position = position.position;
            explosion.Play();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}