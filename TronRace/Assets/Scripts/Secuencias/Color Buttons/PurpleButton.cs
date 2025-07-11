using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PurpleButton : ColorButton
    {
        #region UNITY METHODS
 
        #endregion

        #region VARIABLES
        [SerializeField] private ColorButton orangeButton;

        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS

        protected override int ChooseWall()
        {
            var rand = Random.Range(0, 10);
            var adyacent = rand < 5 ? -1 : 1;
            var orange = Mathf.Max(0, orangeButton.SpawnedWall) ;
            var newWall = orange + adyacent;
            if (newWall < 0) newWall = 2;
            return (newWall) % 3;
        }
        #endregion
    }
}