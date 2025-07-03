using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class SimpleRotation : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {

            var dir = local ? transform.up : Vector3.up;
            if (affectedObject == null)
            {
                transform.Rotate(dir, Mathf.PI * AngularRotation);
            }
            else {
                affectedObject.Rotate(dir, Mathf.PI * AngularRotation);
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private float AngularRotation = 1;
        [SerializeField] private bool local = false;
        [SerializeField] private Transform affectedObject;
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