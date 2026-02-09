using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class SimpleStaticTargetGame : MonoBehaviour
    {
        #region VARIABLES
        [SerializeField]
        private TargetController controller;
        #endregion

        #region PUBLIC METHODS
        public void ChangeObjective()
        {
            controller.ChangeObjective();
        }
        #endregion
    }
}