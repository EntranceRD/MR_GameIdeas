using Entrance.Games;
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
            instructionsDisplayer.OnFinishDisplaying += () =>
            {
                gameTime.Resume();
                ReleaseBalls();
                squashMusic.Play();
                backgroundMusic.Stop();
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
        [SerializeField] private Entrance.Games.InstructionsDisplayer instructionsDisplayer;
        [SerializeField] private SquashBallGenerator squashBallGenerator;
        [SerializeField] private AudioSource squashMusic;
        [SerializeField] private AudioSource backgroundMusic;
        [SerializeField, Range(2, 10)] private int amountOfPlayers;
        [SerializeField] private bool instructionsOneByOne = false;
        #endregion

        #region PUBLIC METHODS
        public void StartGame()
        {
            Restart();
            instructionsDisplayer.Display(instructionsOneByOne);
        }

        public void EndGame()
        {
            squashBallGenerator.StopPlayers();
            //instructionDisplayer.DisplayGameOver();
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            squashMusic.Stop();
            gameTime.Restart();
            squashBallGenerator.Restart();
            instructionsDisplayer.Restart();
            backgroundMusic.Play();
        }

        public void PreparePlayers()
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