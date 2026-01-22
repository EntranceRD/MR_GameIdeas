using UnityEngine;

public class CarVelocityController : MonoBehaviour
{
    #region UNITY METHODS

    private void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
        velocity = baseVelocity;
        clickCounter.OnCountedFrame += (int clicks) =>
        {
            velocity = baseVelocity + (clickMultiplier * clicks);
        };
    }

    private void FixedUpdate()
    {
        if(finished) return;

        Vector3 pos = transform.position;
        pos.z += velocity * Time.deltaTime;
        transform.position = pos;
    }

    #endregion

    #region VARIABLES

    public int driverID = 0;
    public float baseVelocity = .1f;
    public float velocity;
    public bool finished = false;
    public Vector3 startPosition;
    public float clickMultiplier = .2f;
    public ClickCounterByFrame clickCounter;

    #endregion

    #region PUBLIC METHODS
    public void RestartCar()
    {
        clickMultiplier = .2f;
        velocity = baseVelocity;
        transform.position = startPosition;
        finished = false;
    }

    public void StopCar()
    {
        finished = true;
    }

    #endregion

    #region PRIVATE METHODS

    #endregion
}