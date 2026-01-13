using Entrance.Games.Mathematics;
using System.Collections.Generic;
using UnityEngine;
using Entrance.Unity;

namespace CalculosGameManager
{
    public class GameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            Restart();
            gameTime.Restart();
            gameTime.OnFinish += FinishGame;
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public List<GameManager_MathBoard> gameManager_MathBoard;
        public List<Player> players;
        public Timer gameTime;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            for (int i = 0; i < gameManager_MathBoard.Count; i++)
            {
                gameManager_MathBoard[i].Restart();
            }
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Restart();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void FinishGame()
        {
            
        }
        #endregion
    }
}