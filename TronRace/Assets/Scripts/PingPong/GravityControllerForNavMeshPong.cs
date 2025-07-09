using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class GravityControllerForNavMeshPong : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            affectedObjects.SimpleIteration((obj) => {
                obj.position += Vector3.up * -gravity * Time.deltaTime;
            });
        }
        #endregion

        #region VARIABLES
        [SerializeField, Range(0, 1)] private float gravity = 0.1f;
        [SerializeField] private ObjectGroup<Transform> affectedObjects;
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