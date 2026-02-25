using Entrance.Games;
using Entrance.Games.Demos;
using TMPro;
using UnityEngine;

namespace EntranceGames.Squash 
{
    public class SquashBall : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            teleportable.OnTeleport += (newPoint) =>
            {
                movible.FindNewTarget();
            };
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Teleport.TeleportableObject teleportable;
        [SerializeField] private ScoreManager scoreManager;
        public MovibleElement movible;
        #endregion

        #region PUBLIC METHODS
        public void SetDisplay(TextMeshProUGUI displayTxt)
        {
            scoreManager.displayPoints = displayTxt;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}