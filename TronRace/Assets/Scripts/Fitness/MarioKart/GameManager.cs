using Entrance.Unity;
using UnityEngine;

namespace Entrance.Games.MarioKart
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
            instructionsDisplayer.OnEndDisplaying -= StartRace;
            instructionsDisplayer.OnEndDisplaying += StartRace;
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
        public System.Action OnGameStop;

        [Header("References")]
        [SerializeField] private Ranking ranking;
        [SerializeField] private GenericTimerComponent gameTime;
        [SerializeField] private LanesHolder lanesHolder;
        [SerializeField] private InstructionsDisplayer instructionsDisplayer;

        [Header("Settings")]
        [SerializeField, Range(2, 7)] private int amountOfPlayers;
        #endregion

        #region PUBLIC METHODS
        public void StartGame(int players)
        {
            Restart();
            lanesHolder.InitializeLanes(players);
            instructionsDisplayer.DisplayInstructions();
        }

        public void StartRace()
        {
            lanesHolder.StartRace();
        }

        public void StopGame()
        {
            EndRace();
            OnGameStop?.Invoke();
        }

        public int SetPlayers(int players)
        {
            return amountOfPlayers = players;
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            lanesHolder.Restart();
            ranking.Restart();
            instructionsDisplayer.Restart();
            RestartTimers();
        }

        private void RestartTimers()
        {
            gameTime.Restart();
            gameTime.Resume();
        }
        private void EndRace()
        {
            foreach (var car in lanesHolder.cars)
            {
                if (car != null & !car.canMove)
                {
                    ranking.AddPlayer(car.driverID);
                }
            }
            ranking.DisplayRanking();
        }
        #endregion
    }
}