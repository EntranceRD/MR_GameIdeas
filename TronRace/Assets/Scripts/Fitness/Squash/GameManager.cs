using Entrance.Unity;
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
            instructionsDisplayer.OnEndDisplaying += () =>
            {
                gameTime.Resume();
                ReleaseBalls();
            };
            instructionsDisplayer.OnEndInstructions += () =>
            {
                PreparePlayers();
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartGame();
            }
        }
        #endregion

        #region VARIABLES
        public static GameManager Instance;
        [SerializeField] private GenericTimerComponent gameTime;
        [SerializeField] private InstructionsDisplayer instructionsDisplayer;
        [SerializeField] private SquashBallGenerator squashBallGenerator;
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
            squashBallGenerator.StopPlayers();
            instructionsDisplayer.DisplayGameOver();
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            gameTime.Restart();
            squashBallGenerator.Restart();
            instructionsDisplayer.Restart();
        }

        private void PreparePlayers()
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                squashBallGenerator.PreparePlayer(i);
            }
        }

        private void ReleaseBalls()
        {
            squashBallGenerator.ReleasePlayers();
        }
        #endregion
    }
}