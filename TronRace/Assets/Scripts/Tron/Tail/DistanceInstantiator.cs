using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Tron
{
    [System.Serializable]
    public class DistanceInstantiator
    {
        #region CONSTRUCTORS
        public DistanceInstantiator()
        {
            
        }
        #endregion

        #region VARIABLES
        private Vector3 lastInstancePosition;
        [SerializeField, Range(0, 1)] private float instantiationDistance = 0.2f;
        #endregion

        #region PUBLIC METHODS
        public bool HasToInstantiate(Vector3 position)
        {
            var dist = Vector3.Distance(position, lastInstancePosition);
            return (dist >= instantiationDistance);
        }
        public void RegisterPosition(Vector3 position) {
            lastInstancePosition = position;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}