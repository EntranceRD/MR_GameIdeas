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
        [Header("References")]
        public static GameManager Instance;
        //public ColorSequence colorSequence;
        public GenericTimerComponent gameTime;
        //public ScoreManager scoreManager;

        [Header("Settings")]
        [SerializeField, Range(2, 5)] private int amountOfPlayers;
        [SerializeField] private ColorBoard[] colorBoards;

        public System.Action OnGameStop;
        public List<int> scoreBoard = new List<int>();
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
            OnGameStop?.Invoke();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                scoreBoard.Add(colorBoards[i].finalPoints);
            }
            scoreBoard.Sort((a, b) => b.CompareTo(a)); ;
            Debug.Log(string.Join(", ", scoreBoard));
        }

        //public void BoardGuessRightSequence(ColorBoard board)
        //{
        //    for (int i = 0; i < colorBoards.Length; i++)
        //    {
        //        colorBoards[i].CleanBoard();
        //    }
        //    var sequence = colorSequence.GrowSequenceBy(1);
        //    InitializeBoards(sequence);
        //}
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            gameTime.Restart();
            gameTime.Resume();
            scoreBoard.Clear();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].Restart();
            }
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