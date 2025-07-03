using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class TopoButton : MonoBehaviour
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
        public System.Action OnClick;
        private ButtonPosition position;
        #endregion

        #region PUBLIC METHODS
        public void Click()
        {
            OnClick?.Invoke();
            if (position != null) { 
                position.free = true;
            }
        }
        public void SetPosition(ButtonPosition pos) {
            transform.position = pos.transform.position;
            pos.free = false;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}