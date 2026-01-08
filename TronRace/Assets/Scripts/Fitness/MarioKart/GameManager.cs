using Entrance.Unity;
using UnityEngine;

namespace MarioKartGameManager
{
    public class GameManager : MonoBehaviour
    {
        #region UNITY METHODS

        private void Awake()
        {
            InitializeTime();
        }

        private void Start()
        {
            lanesHolder.InitializeLanes(players);
            gameTime.OnFinish += EndRace;
            gameTime.Restart();
        }

        private void Update()
        {
            gameTime.Tick(Time.deltaTime);
            stopwatch.Tick(Time.deltaTime);
        }

        #endregion

        #region VARIABLES

        [SerializeField, Range(2, 10)] private int players;
        public float gameDuration = 30f;
        public Ranking ranking;
        public Timer gameTime;
        public Stopwatch stopwatch;
        public LanesHolder lanesHolder;

        #endregion

        #region PUBLIC METHODS

        public void Restart()
        {
            InitializeTime();
            gameTime.Restart();
            stopwatch.Restart();

            lanesHolder.Restart();
            lanesHolder.InitializeLanes(players);

            ranking.ClearRanking();
        }

        public void AddCarToRanking(CarVelocityController car)
        {
            ranking.AddPlayer(car.driverID, stopwatch.SetFlag());
        }

        public void EndRace()
        {
            foreach (var car in lanesHolder.cars)
            {
                if (car != null & !car.finished)
                {
                    ranking.AddPlayer(car.driverID, gameTime.Target);
                }
            }
            ranking.SortByTime();
            ranking.DisplayRanking();
        }

        #endregion

        #region PRIVATE METHODS

        private void InitializeTime()
        {
            gameTime.Target = gameDuration;
            stopwatch.Target = gameDuration;
        }

        #endregion
    }
}