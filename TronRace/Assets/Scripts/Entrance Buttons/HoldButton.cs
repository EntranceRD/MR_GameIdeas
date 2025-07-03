using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entrance.Unity;

namespace Entrance 
{
    [System.Serializable]
    public class HoldButton : ClickableElement, IImageFiller
    {
        #region CONSTRUCTORS
        public HoldButton() : base()
        {
            holdTime = new Timer()
            {
                OnFinish = () => {
                    clicked = true;
                    OnClick.Call();
                }
            };
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private Timer holdTime = new Timer();
        private bool preClciking = false;
        public ButtonEvent OnInitialClick;
        public float amount { get; private set; } = 0f;
        #endregion

        #region PUBLIC METHODS
        public override void Update()
        {
            cancellationTime.Tick(Time.deltaTime);
            if (preClciking) {
                amount = 1f - (holdTime.Remaining / holdTime.Target);
                holdTime.Tick(Time.deltaTime);
            }
        }
        public override void Awake()
        {
            cancellationTime = new Timer() { Target = 0.2f };
            cancellationTime.OnFinish = () => {
                clicked = false;
                preClciking = false;
                OnRelease.Call();
            };
        }
        public override void Restart()
        {
            base.Restart();
            holdTime.Restart();
            preClciking = false;
            amount = 0f;
        }
        #endregion

        #region PRIVATE METHODS
        protected override bool clickCondition(Interaction.Touch touch)
        {
            switch (touch.phase)
            {
                case Interaction.TouchPhase.START:
                case Interaction.TouchPhase.STATIONARY:
                case Interaction.TouchPhase.MOVED:
                    if (!preClciking) { 
                        preClciking = true;
                        OnInitialClick.Call();
                        holdTime.Restart();
                    }
                    cancellationTime.Restart();
                    return clicked;
                default:
                    return false;
            }
        }
        #endregion
    }
}