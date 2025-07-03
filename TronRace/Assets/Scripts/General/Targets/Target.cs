using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance
{
    public abstract class Target : MonoBehaviour
    {
        #region UNITY METHODS
        public void Awake()
        {
            trans = GetComponent<Transform>();
        }
        #endregion

        #region VARIABLES
        public Action action;

        protected Transform trans;
        protected Transform objective;

        #endregion

        #region PUBLIC METHODS
        public virtual void SetObjective(Transform o)
        {
            objective = o;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {

        }
        #endregion
    }
}