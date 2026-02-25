using Entrance.Unity;
using EntranceGames.Squash;
using UnityEngine;

namespace Entrance.Games.Squash
{
    public class GameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            timeToStart.OnFinish = () => {
                DisplayInstructions();
            };
            instructionsDisplayer.OnEndDisplaying += StartGame;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ClickAllBalls();
            }
        }
        #endregion

        #region VARIABLES
        public static GameManager Instance;
        [SerializeField] private Timer timeToStart;
        [SerializeField] private InstructionsDisplayer instructionsDisplayer;
        [SerializeField] private SpeedModifier[] balls;
        public int amount = 0;
        #endregion

        #region PUBLIC METHODS
        public void DisplayInstructions()
        {
            Restart();
            instructionsDisplayer.Display();
        }

        public void StartGame()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            instructionsDisplayer.Restart();
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].Restart();
            }
        }

        private void ClickAllBalls()
        {
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].MoveStep(amount);
            }
        }
        #endregion
    }
}