using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class MovingTarget:Target
    {
        #region CONSTRUCTORS
        public MovingTarget()
        {
            objective = null;
        }
        #endregion

        #region UNITY METHODS
        private void  Update()
        {
            if (objective == null) return;

            MoveToObjective();

            var dist = (objective.position - trans.position).sqrMagnitude;
            if (dist < MinDistance) {
                action?.Invoke();
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField,Range(0,1)]
        public float MinDistance = 0.1f;
        [SerializeField,Range(0,10)]
        public float Speed = 1f;
        #endregion

        #region PUBLIC METHODS
        public override void SetObjective(Transform o)
        {
            objective = o;
        }
        #endregion

        #region PRIVATE METHODS
        private void MoveToObjective()
        {
            var dir = (objective.position - trans.position).normalized;
            trans.position += dir * Speed * Time.deltaTime;
        }
        #endregion
    }
}