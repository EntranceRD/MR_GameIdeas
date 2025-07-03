using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ObjectHider : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            gameObject.SetActive(false);
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