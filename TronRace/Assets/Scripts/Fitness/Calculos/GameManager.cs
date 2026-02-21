using Entrance.Games.Mathematics;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Mathematics
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
        private void Start()
        {
            instructionsDisplayer[0].OnEndDisplaying -= StartGame;
            instructionsDisplayer[0].OnEndDisplaying += StartGame;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartInstructions();
            }
        }
        #endregion

        #region VARIABLES
        public static GameManager Instance;
        public System.Action OnGameStop;

        [Header("References")]
        [SerializeField] private MathBoardManager[] mathBoardManagers;
        [SerializeField] private InstructionsDisplayer[] instructionsDisplayer;
        [SerializeField] private Ranking ranking;
        [SerializeField] private GenericTimerComponent gameTime;
        [SerializeField] private GameObject[] gameOverPanels;

        [Header("Settings")]
        [Range(1, 5)] public int playersPerTeam = 2;

        [Header("FakePlayers")]
        public List<Player> fakePlayers;
        public bool activeFakePlayers;
        #endregion

        #region PUBLIC METHODS
        public void StartInstructions()
        {
            Restart();
            for (int i = 0; i < instructionsDisplayer.Length; i++)
            {
                instructionsDisplayer[i].DisplayInstructions();
            }
            //instructionsDisplayer.DisplayInstructions();
        }

        public void EndGame()
        {
            GameZoneState(false);
            GameOverPanelsState(true);
            OnGameStop?.Invoke();
        }

        public void StartGame()
        {
            GameZoneState(true);
            InitializeGameZones(playersPerTeam);
        }

        public void Restart()
        {
            gameTime.Restart();
            gameTime.Resume();
            ranking.Restart();
            for (int i = 0; i < instructionsDisplayer.Length; i++)
            {
                instructionsDisplayer[i].Restart();
            }
            GameZoneState(false);
            GameOverPanelsState(false);
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

        private void GameOverPanelsState(bool state)
        {
            for (int i = 0; i < gameOverPanels.Length; i++)
            {
                gameOverPanels[i].gameObject.SetActive(state);
            }
        }
        #endregion
    }
}