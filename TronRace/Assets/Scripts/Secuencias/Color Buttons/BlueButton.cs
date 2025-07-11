using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class BlueButton : ColorButton
    {
        #region UNITY METHODS

        #endregion

        #region VARIABLES
        private bool isOnLeftWall = false;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        protected override int ChooseWall()
        {
            //base.ChooseWall();
            isOnLeftWall = !isOnLeftWall;
            return isOnLeftWall ? 1 : 0;
        }
        #endregion
    }
}