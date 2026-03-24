using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class GeneralAnimator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            if(anim==null) { anim = GetComponent<Animator>(); }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private string animationStateID;
        [SerializeField] private Animator anim;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            if (anim == null) { return; }
            //SetAnimationStateValue(0);
            anim.SetInteger(animationStateID, 0);
        }

        public void SetAnimationStateValue(int stateValue)
        {
            if (anim == null) { return; }
            anim.SetInteger(animationStateID, stateValue);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}