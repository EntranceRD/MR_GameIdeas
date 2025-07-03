using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class BalloonExplosionInstantiator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public static BalloonExplosionInstantiator Instance;
        public ObjectInstantiator explosionInstantiator;
        #endregion

        #region PUBLIC METHODS
        public void CreateExplosion(Transform position, Color color)
        {
            var explosion = explosionInstantiator.Instantiate(position);
            var particles = explosion.GetComponent<ParticleSystem>();
            var main = particles.main;
            main.startColor = color;
            particles.Play();
            StartCoroutine(RecycleExplosion(explosion));
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator RecycleExplosion(Transform obj)
        {
            yield return new WaitForSeconds(5);
            obj.GetComponent<PoolableObject>().Recycle();
        }
        #endregion
    }
}