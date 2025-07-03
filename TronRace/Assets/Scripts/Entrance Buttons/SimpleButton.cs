using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class SimpleButton:ClickableElement
    {
        #region CONSTRUCTORS
        public SimpleButton()
        {
            
        }
        #endregion

        #region VARIABLES
        //private int varA = 0;
        #endregion

        #region PUBLIC METHODS
        //public void Method()
        //{
            
        //}
        #endregion

        #region PRIVATE METHODS
        protected override bool clickCondition(Interaction.Touch touch)
        {
            switch (touch.phase)
            {
                case Interaction.TouchPhase.START:
                case Interaction.TouchPhase.STATIONARY:
                case Interaction.TouchPhase.MOVED:
                    //return !clicked;
                    return true;
                default: return false;
            }
        }
        #endregion
    }
}