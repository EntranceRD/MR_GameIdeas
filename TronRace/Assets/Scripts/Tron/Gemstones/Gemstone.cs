using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Tron.Gemstones
{
    public class Gemstone : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var collector = other.GetComponent<IGemstoneCollector>();
            if (collector != null) {
                collector.CollectGemstone(this);
                gameObject.SetActive(false);
            }
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