using Entrance;
using Entrance.Games;
using Entrance.Games.Demos;
using Entrance.Squash;
using EntranceGames.Teleport;
using TMPro;
using UnityEngine;

namespace Entrance.Games.Squash
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
        [SerializeField] private TeleportableObject teleportable;
        //public ScoreManager scoreManager;
        [SerializeField] private MaterialController materialController;
        [SerializeField] private MovibleElement movible;
        #endregion

        #region PUBLIC METHODS
        public void Initialize(Color color, SurfacePoints surface, Vector3 position) 
        {
            transform.position = position;
            materialController.ChangeColor(color);
            movible.SetSurface(surface);
            movible.SetSpeed(0);
            gameObject.SetActive(true);
        }

        public void Active(float value)
        {
            movible.SetSpeed(value);
            movible.FindNewTarget();
        }

        public void Restart()
        {
            //scoreManager.Restart();
            materialController.Restart();
            movible.Restart();
            gameObject.SetActive(false);
        }

        //public void SetDisplay(TextMeshProUGUI displayTxt)
        //{
        //    scoreManager.displayPoints = displayTxt;
        //}
        #endregion

        #region PRIVATE METHODS
        private void method()
        {

        }
        #endregion
    }
}