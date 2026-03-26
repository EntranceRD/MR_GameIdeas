using Entrance.Games.Sequence;
using Entrance.Games.Squash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games
{
    public class SecuenciaGameManager : MonoBehaviour
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
        public static SecuenciaGameManager Instance;

        [Header("Settings")]
        [SerializeField, Range(2, 50)] private int amountOfPlayers;
        [SerializeField] private GenericTimerComponent gameTime;

        [Header("Logic")]
        [SerializeField] private ColorBoard[] colorBoards;

        [Header("Rank")]
        [SerializeField] private TheRanking ranking;
        [SerializeField] private FloorBoard floorBoard;

        [Header("Instructions")]
        [SerializeField] private InstructionsDisplayer instructionsDisplayer;

        [Header("Audio")]

        [Header("GameOver")]
        [SerializeField] private GameOverController gameOverController;

        //[Header("Others")]
        #endregion

        #region PUBLIC METHODS
        public void StartGame()
        {
            Restart();
            InitializeBoards();
            instructionsDisplayer.Display();
        }

        public void EndGame()
        {
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].GameStop();
            }
            ranking.ShowRanking(GetBoardsScores());
            gameOverController.Display();
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            gameTime.Restart();
            instructionsDisplayer.Restart();
            ranking.Restart();
            gameOverController.Restart();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].Restart();
            }
            floorBoard.Restart();
        }

        public void InitializeBoards()
        {
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].InitializeBoard(amountOfPlayers);
                //colorBoards[i].DisplaySequence();
            }

        }

        public void DisplaysSequence()
        {
            for (int i = 0; i < colorBoards.Length; i++)
            {
                //colorBoards[i].InitializeBoard(amountOfPlayers);
                colorBoards[i].DisplaySequence();
            }
        }

        private Dictionary<int, int> GetBoardsScores()
        {
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                dictionary.Add(i, colorBoards[i].score);
            }
            return dictionary;
        }
        #endregion
    }
}