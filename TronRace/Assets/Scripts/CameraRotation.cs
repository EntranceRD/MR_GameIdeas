using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class CameraRotation : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            var dir = 0;
            if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)) { dir -= 1; }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) { dir += 1; }
            transform.Rotate(Vector3.up, dir * angularSpeed * Time.deltaTime, Space.World);
        }
        #endregion

        #region VARIABLES
        [SerializeField,Range(0,360)] private int angularSpeed = 60;
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