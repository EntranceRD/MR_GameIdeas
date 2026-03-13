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

        [SerializeField] private int amountOfPlayers;
        [SerializeField] private Dictionary<int, int> scores = new Dictionary<int, int>();
        [SerializeField] private BalloonInstantiator[] coinsInstantiators;
        [SerializeField] private ModsGenerator[] modGenerators;
        [SerializeField] private Timer gameTime;
        [SerializeField] private CoinTeamBoard[] boards;
        [SerializeField] private Ranking ranking;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            RestartGenerators();
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
            ModGeneratorsState(true);
            CoinsInstantiatorsState(true);
        }

        public void EndGame()
        {
            GetBoardsScores();
            RestartGenerators();
            CoinsInstantiatorsState(false);
            ModGeneratorsState(false);
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

        private void ModGeneratorsState(bool state)
        {
            for (int i = 0; i < modGenerators.Length; i++)
            {
                modGenerators[i].generatorState = state;
            }
        }

        private void CoinsInstantiatorsState(bool state)
        {
            for (int i = 0; i < coinsInstantiators.Length; i++)
            {
                coinsInstantiators[i].instantiatorState = state;
            }
        }

        private void RestartGenerators()
        {
            for (int i = 0; i < modGenerators.Length; i++)
            {
                modGenerators[i].Restart();
            }
            for (int i = 0; i < coinsInstantiators.Length; i++)
            {
                coinsInstantiators[i].Restart();
            }
        }
        #endregion
    }
}