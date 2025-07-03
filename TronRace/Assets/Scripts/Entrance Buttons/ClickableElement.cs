using System.Collections;
using System.Collections.Generic;
using ETouch = Entrance.Interaction.Touch;
using Entrance.Unity;
using UnityEngine;
using Entrance.Interaction;

namespace Entrance 
{
    [System.Serializable]
    public abstract class ClickableElement:MonoBehaviour, SequenceRequirement, IRestartable, IInteractible
    {
        #region CONSTRUCTORS
        public ClickableElement()
        {

        }
        public virtual void OnEnable() {
            clicked = false;
            //cancellationTime.Restart();
        }
        #endregion

        #region VARIABLES
        public ButtonEvent OnClick;
        public ButtonEvent OnRelease;
        //public System.Action OnClick;
        //public System.Action OnRelease;
        public bool clicked { get; protected set; }
        [SerializeField]
        protected Timer cancellationTime;
        public bool completed => clicked;
        public System.Action<ETouch> OnInteract { get; set; }
        #endregion

        #region PUBLIC METHODS

        public void Interact(ETouch touch) { Click(touch); }
        public void Click(ETouch touch)
        {
            if (!clickCondition(touch)) return;

            cancellationTime.Restart();
            if (clicked) return;
            clicked = true;
            OnClick.Call();
        }
        public virtual void Update() {
            if (!clicked) return;
            cancellationTime.Tick(Time.deltaTime);
        }
        //Initialize
        public virtual void Awake()
        {
            if (cancellationTime == null)
            {
                cancellationTime = new Timer() { Target = 0.2f };
            }
                cancellationTime.OnFinish = () =>
                {
                    clicked = false;
                    OnRelease.Call();
                };
        }
        public virtual void Restart() {
            clicked = false;
        }
        #endregion

        #region PRIVATE METHODS
        protected virtual bool clickCondition(ETouch touch)
        {
            switch (touch.phase) {
                case Interaction.TouchPhase.START:return true;
                default: return false;
            }
        }
        #endregion
    }
}