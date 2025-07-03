using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Entrance 
{
    [System.Serializable]
    public struct ButtonEvent
    {
        #region CONSTRUCTORS
        //public ButtonEvent()
        //{
            
        //}
        #endregion

        #region VARIABLES
        [SerializeField] private UnityEvent @event;
        #endregion

        #region PUBLIC METHODS
        public void Call()
        {
            @event.Invoke();
        }
        public void AddAction(UnityAction action) {
            @event.AddListener(action);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}