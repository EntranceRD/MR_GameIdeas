using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class tempSquashInput : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            direction.x = 0f;
            direction.y = 0f;
            direction.z = 0f;
            if (Input.GetKey(KeyCode.W)) { direction += transform.up; }
            if (Input.GetKey(KeyCode.S)) { direction -= transform.up; }
            if (Input.GetKey(KeyCode.D)) { direction += transform.right; }
            if (Input.GetKey(KeyCode.A)) { direction -= transform.right; }

            transform.position += direction.normalized * speed * Time.deltaTime;
        }
        #endregion

        #region VARIABLES
        [SerializeField,Range(0,10f)] private float speed = 1f;
        private Vector3 direction = Vector3.zero;
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