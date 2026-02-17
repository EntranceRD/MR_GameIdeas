using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.MarioKart
{
    public class LanesHolder : MonoBehaviour
    {
        #region VARIABLES
        [Header("References")]
        public List<CarVelocityController> cars = new List<CarVelocityController>();
        [SerializeField] private List<ClickCounterByFrame> laneList = new List<ClickCounterByFrame>();
        [SerializeField] private List<ClickCounterByFrame> lanesActive = new List<ClickCounterByFrame>();
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            for (int i = 0; i < laneList.Count; i++)
            {
                laneList[i].gameObject.SetActive(false);
            }

            foreach (var car in cars)
            {
                if (car != null)
                {
                    car.RestartCar();
                }
            }
            cars.Clear();
            lanesActive.Clear();
        }

        public void InitializeLanes(int amountOfPlayers)
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                laneList[i].gameObject.SetActive(true);
                lanesActive.Add(laneList[i]);
                CarVelocityController carController = lanesActive[i].GetComponentInChildren<CarVelocityController>();
                carController.driverID = i + 1;
                cars.Add(carController);
            }
            AllowCarMovement(false);
        }

        public void StartRace()
        {
            AllowCarMovement(true);
        }
        #endregion

        #region PRIVATE METHODS
        private void AllowCarMovement(bool state)
        {
            foreach (var car in cars)
            {
                if (car != null)
                {
                    car.CarMoveState(state);
                }
            }
        }
        #endregion
    }
}