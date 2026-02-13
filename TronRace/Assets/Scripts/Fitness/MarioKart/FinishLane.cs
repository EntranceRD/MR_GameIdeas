using UnityEngine;
using Entrance.Games.MarioKart;

namespace Entrance.Games.MarioKart
{
    public class FinishLane : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var car = other.GetComponent<CarVelocityController>();
            if (car != null)
            {
                ranking.AddPlayer(car.driverID);
                car.CarMoveState(false);
            }
            ranking.DisplayRanking();
        }
        #endregion

        #region VARIABLES
        public Ranking ranking;
        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}