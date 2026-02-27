using Entrance.Squash;
using Entrance.Games.Squash;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Entrance.Games.Squash
{
    public class PlayerController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {

        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ScoreController scoreManager;
        [SerializeField] private SquashScoreBoard scoreBoard;
        [SerializeField] private SquashBall[] balls;
        [SerializeField] private BalloonExplosionInstantiator explosionInstantiatior;
        [SerializeField] private string playerID;
        public int score { get { return scoreManager.currentPoints; } }
        #endregion

        #region PUBLIC METHODS
        public void InitializeBoard(string name, Color color)
        {
            scoreBoard.Initialize(name, color);
            //ball.SetDisplay(playerScore);
        }

        public void SetupGameStart(Color color, SurfacePoints surface, Vector3 position) {
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].Initialize(color, surface, position);
            }
            explosionInstantiatior.Initialize(color);
            InitializeBoard(playerID, color);
        }

        public void DiseableBalls()
        {
            foreach (var ball in balls)
            {
                ball.gameObject.SetActive(false);
            }
        }

        public void ReleaseBalls()
        {
            foreach (var ball in balls)
            {
                ball.Active(0.5f);
            }
        }

        public void Restart()
        {
            scoreManager.Restart();
            scoreBoard.Restart();
            foreach (var ball in balls)
            {
                ball.Restart();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}