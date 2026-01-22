using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LanesHolder : MonoBehaviour
{
    #region UNITY METHODS

    #endregion

    #region VARIABLES
    [SerializeField] private List<ClickCounterByFrame> laneList = new List<ClickCounterByFrame>();
    public List<CarVelocityController> cars = new List<CarVelocityController>();
    [SerializeField] private List<ClickCounterByFrame> lanesActive = new List<ClickCounterByFrame>();
    
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
    }

    #endregion

    #region PRIVATE METHODS

    #endregion
}