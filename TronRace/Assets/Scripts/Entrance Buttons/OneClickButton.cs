using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class OneClickButton:ClickableElement
    {
        #region CONSTRUCTORS
        public OneClickButton()
        {
            
        }
        #endregion

        #region PUBLIC METHODS
        public override void Restart()
        {
            base.Restart();
            OnRelease.Call();
        }
        public override void Update()
        {
            //base.Update();
        }
        #endregion

        #region PRIVATE METHODS
        protected override bool clickCondition(Interaction.Touch touch)
        {
            switch (touch.phase) {
                case Interaction.TouchPhase.START:
                case Interaction.TouchPhase.STATIONARY:
                case Interaction.TouchPhase.MOVED:
                    return !clicked;
                default: return false;
            }
        }
        #endregion
    }
}