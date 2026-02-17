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
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }
        #endregion

        #region VARIABLES
        public GameManager_MathBoard[] gameZoneManagers;
        public List<Player> fakePlayers;
        public bool activeFakePlayers;
        [Range(1, 5)] public int playersPerTeam = 2;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            InitializeGameZones(playersPerTeam);
            if (activeFakePlayers)
            {
                InitializeFakePlayers();
            }
        }
        #endregion

        #region PRIVATE METHODS

        private void InitializeGameZones(int amountOfPLayers)
        {
            for (int i = 0; i < gameZoneManagers.Length; i++)
            {
                gameZoneManagers[i].Restart();
                gameZoneManagers[i].InitializePlayers(amountOfPLayers);
            }
        }

        private void InitializeFakePlayers()
        {
            for (int i = 0; i < fakePlayers.Count; i++)
            {
                fakePlayers[i].Restart();
            }
        }

        #endregion
    }
}