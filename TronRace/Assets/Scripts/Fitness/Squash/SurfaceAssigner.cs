using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Squash 
{
    public class SurfaceAssigner: MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var movibleElement = other.gameObject.GetComponent<MovibleElement>();
            if (movibleElement != null)
            {
                movibleElement.SetSurface(surfacePoints);
                //movibleElement.FindNewTarget();
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private SurfacePoints surfacePoints;
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