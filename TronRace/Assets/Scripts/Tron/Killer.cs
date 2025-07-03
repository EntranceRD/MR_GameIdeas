using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Killer : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var lifeElement = other.GetComponent<LifeElement>();
            //if (lifeElement == null) { return; }
            lifeElement?.TakeDamage(1);
        }
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        private int varA = 0;
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