using System;
using UnityEngine;

namespace Entrance 
{
    public class PoolableObject:MonoBehaviour
    {
        #region CONSTRUCTORS
        public PoolableObject()
        {
            
        }
        #endregion

        #region UNITY METHODS
        private void OnEnable()
        {
            Activate();
        }
        private void OnDisable()
        {
            Recycle();
        }
        #endregion

        #region VARIABLES
        public bool active { get; protected set; } = false;
        public ButtonEvent OnActivation;
        public ButtonEvent OnRecycle;
        #endregion

        #region PUBLIC METHODS
        public void Recycle()
        {
            if (!active) return;
            active = false;
            OnRecycle.Call();
        }
        public void Activate() {
            //if (active) return;
            active = true;
            OnActivation.Call();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}