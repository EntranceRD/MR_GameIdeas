using Entrance.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Coins 
{
    public class GameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            gameTime.OnFinish -= EndGame;
            gameTime.OnFinish += EndGame;
        }

        private void Update()
        {
            gameTime.Tick(Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartGame();
            }
        }
        #endregion

        #region VARIABLES
        public Action OnStartGame;
        public Action OnEndGame;
        [Header("Settings")]
        [SerializeField] private int amountOfTeams;
        [SerializeField] private int playersPerTeam;
        [SerializeField] private Timer gameTime;

        [Header("References")]
        [SerializeField] private CoinTeamBoard[] boards;
        [SerializeField] private Ranking ranking;
        private Dictionary<int, int> scores = new Dictionary<int, int>();
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            for (int i = 0; i < boards.Length; i++)
            {
                boards[i].Restart();
            }
            gameTime.Restart();
            ranking.Restart();
            scores.Clear();
        }

        public void StartGame()
        {
            Restart();
            for (int i = 0; i < boards.Length; i++)
            {
                boards[i].GeneratorsState(true);
            }
        }

        public void EndGame()
        {
            GetBoardsScores();
            for (int i = 0; i < boards.Length; i++)
            {
                boards[i].GeneratorsState(false);
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void GetBoardsScores()
        {
            for (int i = 0; i < boards.Length; i++)
            {
                scores.Add(i+1, boards[i].GetScore());
            }
            ranking.ShowRanking(scores);
        }
        #endregion
    }
}