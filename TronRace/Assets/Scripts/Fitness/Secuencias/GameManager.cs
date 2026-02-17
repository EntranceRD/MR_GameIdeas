using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Sequence
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartGame(amountOfPlayers);
            }
        }
        #endregion

        #region VARIABLES
        public static GameManager Instance;
        [Header("References")]
        [SerializeField] private GenericTimerComponent gameTime;
        [SerializeField] private ColorBoard[] colorBoards;
        [SerializeField] private FloorBoard floorBoard;
        [SerializeField] private Ranking ranking;
        //public ScoreManager scoreManager;
        //public ColorSequence colorSequence;

        [Header("Settings")]
        [SerializeField, Range(2,50)] private int amountOfPlayers;
        public System.Action OnGameStop;
        #endregion

        #region PUBLIC METHODS
        public int SetPlayers(int players)
        {
            return amountOfPlayers = players;
        }

        public void StartGame(int amountOfPLayers)
        {
            Restart();
            InitializeBoards(amountOfPLayers);
        }

        public void StopGame()
        {
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].GameStop();
            }
            OnGameStop?.Invoke();
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            gameTime.Restart();
            gameTime.Resume();
            ranking.Restart();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].Restart();
            }
            floorBoard.Restart();
        }

        private void InitializeBoards(int totalPlayers)
        {
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].InitializeBoard(totalPlayers);
                colorBoards[i].DisplaySequence();
            }
        }
        #endregion
    }
}