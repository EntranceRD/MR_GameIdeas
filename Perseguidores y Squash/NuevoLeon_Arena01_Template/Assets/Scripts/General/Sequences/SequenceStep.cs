using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class SequenceStep:MonoBehaviour
    {
        //#region CONSTRUCTORS
        //public SequenceStep()
        //{
            
        //}
        //#endregion

        #region VARIABLES
        public ClickableElement[] requirements;
        public ClickableElement[] NegativeRequirements;

        public ButtonEvent OnStarted;
        public ButtonEvent OnFinish;
        #endregion

        #region PUBLIC METHODS
        public virtual bool isComplete()
        {
            for (int i = 0; i < requirements.Length; ++i)
                if (!requirements[i].completed) 
                    return false;

            for (int i = 0; i < NegativeRequirements.Length; ++i)
                if (NegativeRequirements[i].completed)
                    return false;
            return true;
        }
        public virtual void Restart() {
            for (int i = 0; i < requirements.Length; ++i)
                requirements[i].Restart();
            for (int i = 0; i < NegativeRequirements.Length; ++i)
                NegativeRequirements[i].Restart();
        }
        public virtual void Initialize() {
            OnStarted.Call();
        }
        #endregion
    }
}