using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class GeneratorVisual
    {
        #region CONSTRUCTORS
        public GeneratorVisual()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private RectTransform portalVisual;
        [SerializeField] private ParticleSystem portalParticles;
        #endregion

        #region PUBLIC METHODS
        public void Initialize(float lenght) {
            InitializeImage(lenght);
        }
        public void Initialize(float separation, int count)
        {
            float lenght = /*separation +*/ (separation * count);
            InitializeImage(separation, count);
            InitializePortalEffect(lenght);
        }
        #endregion

        #region PRIVATE METHODS
        private void InitializeImage(float separation, int count)
        {
            if (portalVisual != null)
            {
                var size = portalVisual.sizeDelta;
                size.y = /*separation +*/ (separation * count);
                portalVisual.sizeDelta = size;
            }
        }
        private void InitializeImage(float lenght)
        {
            if (portalVisual != null)
            {
                var size = portalVisual.sizeDelta;
                size.y = lenght;
                portalVisual.sizeDelta = size;
            }
        }
        private void InitializePortalEffect(float lenght) {
            if (portalParticles == null) { return; }
            var shape = portalParticles.shape;
            shape.radius = lenght / 2f;
            var emission = portalParticles.emission;
            emission.rateOverDistanceMultiplier = lenght;
            //portalParticles.shape.radius = lenght / 2f;// = shape;
        }
        #endregion
    }
}