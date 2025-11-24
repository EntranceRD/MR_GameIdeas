using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ExcavationObjectSegment : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public bool isFree = false;
        public ButtonEvent OnFree;
        #endregion

        #region PUBLIC METHODS
        public void SetFree()
        {
            isFree = true;
            OnFree.Call();
        }
        public void Restart() {
            isFree = false;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}