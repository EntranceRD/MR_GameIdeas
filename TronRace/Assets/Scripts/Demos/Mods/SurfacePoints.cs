using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Squash
{
    public class SurfacePoints : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var movibleElement = other.gameObject.GetComponent<MovibleElement>();
            if (movibleElement != null)
            {
                movibleElement.SetSurface(this);
                //movibleElement.FindNewTarget();
            }
        }
        private void Start()
        {

        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        [SerializeField] private ObjectGroup<Transform> points;
        #endregion

        #region PUBLIC METHODS
        public Transform GetRandomPoint()
        {
            return points.GetRandomObject();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {

        }
        #endregion
    }
}