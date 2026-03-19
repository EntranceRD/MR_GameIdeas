using Entrance.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TeamColor
{
    Azul,
    Rojo
}

namespace Entrance.Games.Coins
{
    public class GameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {

        }
        private void Start()
        {
            //gameTime.OnFinish -= EndGame;
            //gameTime.OnFinish += EndGame;
        }

        private void Update()
        {
            //gameTime.Tick(Time.deltaTime);

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
        [SerializeField] private bool BlueVsRed = false;

        [Header("GameTime")]
        [SerializeField] private GenericTimerComponent gameTime;

        [Header("References")]
        [SerializeField] private CoinTeamBoard[] boards;
        [SerializeField] private Ranking ranking;
        private Dictionary<TeamColor, int> boardsRank = new Dictionary<TeamColor, int>();
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
            gameTime.Resume();
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
            if (BlueVsRed)
            {
                boardsRank.Clear();
                boardsRank.Add(TeamColor.Azul, boards[0].GetScore());
                boardsRank.Add(TeamColor.Rojo, boards[1].GetScore());
                ranking.ShowBlueVsRedRanking(boardsRank);
                return;
            }

            for (int i = 0; i < boards.Length; i++)
            {
                scores.Add(i + 1, boards[i].GetScore());
            }
            ranking.ShowRanking(scores);
        }
        #endregion
    }
}