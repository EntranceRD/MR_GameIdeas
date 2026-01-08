using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesHolder : MonoBehaviour
{
    #region UNITY METHODS

    #endregion

    #region VARIABLES

    public List<CarVelocityController> cars = new List<CarVelocityController>();
    [SerializeField] private List<GameObject> laneList = new List<GameObject>();
    [SerializeField] private Vector3 basePos;
    [SerializeField] private Vector3 laneOffset = new Vector3(0f, 0f, 0f);
    public GameObject lanePrefab;

    #endregion

    #region PUBLIC METHODS

    public void Restart()
    {
        foreach (GameObject lane in laneList)
        {
            if (lane != null)
            {
                Destroy(lane);
            }
        }

        foreach (var car in cars)
        {
            if (car != null)
            {
                car.RestartCar();
            }
        }

        laneList.Clear();
        cars.Clear();
    }

    public void InitializeLanes(int amountOfPlayers)
    {
        basePos = transform.position;
        for (int i = 0; i < amountOfPlayers; i++)
        {
            Vector3 position = basePos + laneOffset * i;
            GameObject lane = Instantiate(lanePrefab, position, Quaternion.identity, transform);
            laneList.Add(lane);
            lane.name = "Lane " + (i + 1);
            CarVelocityController carController = lane.GetComponentInChildren<CarVelocityController>();
            carController.driverID = i + 1;
            cars.Add(carController);
        }
    }

    #endregion

    #region PRIVATE METHODS

    #endregion
}