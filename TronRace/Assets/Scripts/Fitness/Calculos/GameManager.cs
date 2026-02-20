using Entrance.Games.Mathematics;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Mathematics
{
    public class GameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            instructionsDisplayer.OnEndDisplaying -= StartMaths;
            instructionsDisplayer.OnEndDisplaying += StartMaths;
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
        [Header("References")]
        [SerializeField] private MathBoardManager[] mathBoardManagers;
        [SerializeField] private InstructionsDisplayer instructionsDisplayer;
        [SerializeField] private GenericTimerComponent gameTime;

        [Header("Settings")]
        [Range(1, 5)] public int playersPerTeam = 2;

        [Header("FakePlayers")]
        public List<Player> fakePlayers;
        public bool activeFakePlayers;
        #endregion

        #region PUBLIC METHODS
        public void StartGame()
        {
            Restart();
            instructionsDisplayer.DisplayInstructions();
        }

        public void EndGame()
        {
            GameZoneState(false);
        }

        public void StartMaths()
        {
            GameZoneState(true);
            InitializeGameZones(playersPerTeam);
        }

        public void Restart()
        {
            gameTime.Restart();
            gameTime.Resume();
            instructionsDisplayer.Restart();
            GameZoneState(false);
            if (activeFakePlayers)
            {
                InitializeFakePlayers();
            }
        }
        #endregion

        #region PRIVATE METHODS

        private void InitializeGameZones(int amountOfPLayers)
        {
            for (int i = 0; i < mathBoardManagers.Length; i++)
            {
                mathBoardManagers[i].Restart();
                mathBoardManagers[i].InitializeGame(amountOfPLayers);
            }
        }

        private void InitializeFakePlayers()
        {
            for (int i = 0; i < fakePlayers.Count; i++)
            {
                fakePlayers[i].Restart();
            }
        }

        private void GameZoneState(bool state)
        {
            for (int i = 0; i < mathBoardManagers.Length; i++)
            {
                mathBoardManagers[i].gameObject.SetActive(state);
            }
        }
        #endregion
    }
}