using ETouch = Entrance.Interaction.Touch;


namespace Entrance 
{
    public class ManualControlButton : ClickableElement
    {
        #region UNITY METHODS
        public override void OnEnable()
        {
            //base.OnEnable();
        }
        #endregion

        #region VARIABLES
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
    protected override bool clickCondition(ETouch touch)
        {
            switch (touch.phase)
            {
                case Interaction.TouchPhase.START:
                case Interaction.TouchPhase.STATIONARY:
                case Interaction.TouchPhase.MOVED:
                    return true;
                default: return false;
            }
        }
        #endregion
    }
}