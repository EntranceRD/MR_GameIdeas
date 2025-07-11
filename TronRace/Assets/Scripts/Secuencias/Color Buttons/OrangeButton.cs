using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class OrangeButton : ColorButton
    {
        #region UNITY METHODS
   
        #endregion

        #region VARIABLES
        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS
        protected override int ChooseWall()
        {
            return Random.Range(0, 3);
       
        }
        #endregion
    }
}