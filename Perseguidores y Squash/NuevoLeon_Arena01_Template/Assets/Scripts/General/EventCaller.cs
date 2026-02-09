using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class EventCaller : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            if (CallOnEnable) {
                Call();
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private bool CallOnEnable = false;
        [SerializeField] private ButtonEvent action;
        #endregion

        #region PUBLIC METHODS
        public void Call()
        {
            action.Call();
        }
        #endregion
    }
}