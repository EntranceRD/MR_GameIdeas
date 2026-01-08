using UnityEngine;

public class FinishLane : MonoBehaviour
{
    #region UNITY METHODS
    private void OnTriggerEnter(Collider other)
    {
        var car = other.GetComponent<CarVelocityController>();
        if (car != null)
        {
            gameManager.AddCarToRanking(car);
            car.StopCar();
        }
    }
    #endregion

    #region VARIABLES
    public MarioKartGameManager.GameManager gameManager;
    #endregion

    #region PUBLIC METHODS

    #endregion

    #region PRIVATE METHODS

    #endregion
}