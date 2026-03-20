using UnityEngine;

namespace Entrance.Games.MarioKart
{
    public class CarVelocityController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            startPosition = transform.position;
            carColor = GetComponent<Renderer>().material.color;
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
            if (!canMove) return;

            Vector3 pos = transform.position;
            pos.x += velocity * Time.deltaTime;
            transform.position = pos;
        }
        #endregion

        #region VARIABLES
        [Header("References")]
        public ClickCounterByFrame clickCounter;

        [Header("Car Info")]
        public int driverID = 0;
        public Color carColor;
        private float velocity;
        private Vector3 startPosition;

        [Header("Settings")]
        public float baseVelocity = .05f;
        public float clickMultiplier = .3f;
        public bool canMove = false;
        #endregion

        #region PUBLIC METHODS
        public void RestartCar()
        {
            clickMultiplier = .3f;
            velocity = baseVelocity;
            transform.position = startPosition;
            CarMoveState(false);
        }

        public void CarMoveState(bool state)
        {
            canMove = state;
        }
        #endregion
    }
}