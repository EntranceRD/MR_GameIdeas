using Entrance.Games.Mathematics;
using System.Collections.Generic;
using UnityEngine;
using Entrance.Unity;

namespace Entrance.Games.Teams
{
    public class RelayRace_GameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            Restart();
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        public List<GameManager_MathBoard> gameManager_MathBoard;
        public List<Player> players;
        [Range(1, 5)] public int playersPerTeam = 2;
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

            InitializeLanesDependingOnPlayers(playersPerTeam);
        }

        public void InitializeLanesDependingOnPlayers(int amountOfPLayers)
        {
            for (int i = 0; i < gameManager_MathBoard.Count; i++)
            {
                gameManager_MathBoard[i].InitializePlayers(amountOfPLayers);
            }
        }
        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}