using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class RedZoneGenerator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            visual.Initialize(length);
            var size = collider.size;
            size.y = length;
            collider.size = size;
            if (displaceCollider) {
                var center = collider.center;
                center.y = length / 2f;
                collider.center = center;
            }
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField,Range(0,10)] private float length = 1f;
        [SerializeField]private GeneratorVisual visual;
        [SerializeField] private BoxCollider collider;
        [SerializeField] private bool displaceCollider = false;
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