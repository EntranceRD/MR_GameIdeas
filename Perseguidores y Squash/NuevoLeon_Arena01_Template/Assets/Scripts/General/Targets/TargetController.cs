using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class TargetController
    {
        #region UNITY METHODS
        public void Initialize()
        {
            if (target == null) return;

            target.action = () => {
                target.SetObjective(targetPositions.GetRandomObject());
            };
        }
        #endregion

        
        #region VARIABLES
        public Target target;

        [SerializeField]
        private ObjectGroup<Transform> targetPositions;
        #endregion

        #region PUBLIC METHODS
        public void ChangeObjective()
        {
            if (target == null) return;

            target.SetObjective(targetPositions.GetRandomObject());
        }
        #endregion
    }
}