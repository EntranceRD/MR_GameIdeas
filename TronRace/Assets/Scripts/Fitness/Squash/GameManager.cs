using Entrance.Unity;
using EntranceGames.Squash;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

namespace Entrance.Games.Squash
{
    public class GameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); return;
            }
            Instance = this;
        }

        private void Start()
        {
            instructionsDisplayer.OnEndDisplaying += () => {
                gameTime.Resume();
                InitializePlayersShapes();
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartGame();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ClickAllBalls();
            }
        }
        #endregion

        #region VARIABLES
        public static GameManager Instance;
        [SerializeField] private GenericTimerComponent gameTime;
        [SerializeField] private InstructionsDisplayer instructionsDisplayer;
        [SerializeField] private SquashBallGenerator squashBallGenerator;
        [SerializeField] private SpeedModifier[] balls;
        [SerializeField] private List<SquashBall> ballsList = new List<SquashBall>();
        [SerializeField] private SquashScoreBoard[] playerScoreBoards;
        public int amount = 0;
        [SerializeField, Range(2, 10)] private int amountOfPlayers;
        #endregion

        #region PUBLIC METHODS
        public void StartGame()
        {
            Restart();
            instructionsDisplayer.Display();
        }

        public void EndGame()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            gameTime.Restart();
            instructionsDisplayer.Restart();
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].Restart();
            }
        }

        private void InitializePlayersShapes()
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                var newBall = squashBallGenerator.InstantiateBall();
                var name = "Player " + (i + 1);
                playerScoreBoards[i].InitializePlayer(name, newBall);
                //AssingPlayerBoard(name, newBall.scoreManager.displayPoints);
            }
        }

        //private void AssingPlayerBoard() 
        //{
        //    for (int i = 0; i < playerScoreBoards.Length; i++)
        //    {
        //        playerScoreBoards[i].InitializePlayer();
        //    }
        //}

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