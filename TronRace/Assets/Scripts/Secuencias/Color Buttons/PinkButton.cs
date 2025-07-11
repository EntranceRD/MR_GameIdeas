using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PinkButton : ColorButton
    {
        #region UNITY METHODS
 
        #endregion

        #region VARIABLES
        [SerializeField] private ColorButton blueButton;

        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS

        protected override int ChooseWall()
        {
            //if (blueButton.SpawnedWall < 0) return 1;
            return blueButton.SpawnedWall == 1 ? 0 : 1;
        }
        #endregion
    }
}