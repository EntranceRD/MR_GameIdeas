using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class RedButton : ColorButton
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
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        protected override int ChooseWall()
        {
            return Mathf.Max(0, (SpawnedWall + 1) % 3);
        }
        #endregion
    }
}