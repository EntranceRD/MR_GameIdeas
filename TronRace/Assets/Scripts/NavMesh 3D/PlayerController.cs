using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance.Tron
{
    public class PlayerController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            //if (Input.GetKey(KeyCode.W)) { StartMovement(MovementDirections.UP); }
            //if (Input.GetKey(KeyCode.S)) { StartMovement(MovementDirections.DOWN); }
            if (Input.GetKeyDown(KeyCode.D)) {
                TurnRight();
                //rightButton.Select();
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                TurnLeft();
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                Restart();
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Navmeshable_Traveler traveler;
        [SerializeField] private TronPlayer player;
        [SerializeField] private TronBikeTail tail;
        private MovementDirections currentDirection = MovementDirections.None;
        [Space]
        public Button rightButton; 
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            //timer call
            //player.TakeDamage(10);
            player.RestartTronPlayer();
            traveler.Restart();
            tail.RestartTail(traveler.startPosition);
        }
        public void TurnRight() {
            currentDirection = traveler.movingDirection;
            currentDirection = GetDirectionToTheRight(currentDirection);
            traveler.SetMovement(currentDirection);
        }
        public void TurnLeft() {
            currentDirection = traveler.movingDirection;
            currentDirection = GetDirectionToTheLeft(currentDirection);
            traveler.SetMovement(currentDirection);
        }
        #endregion

        #region PRIVATE METHODS
        private MovementDirections GetDirectionToTheRight(MovementDirections direction)
        {
            switch (direction) {
                case MovementDirections.None: return MovementDirections.RIGHT;
                case MovementDirections.UP:return MovementDirections.RIGHT;
                case MovementDirections.RIGHT:return MovementDirections.DOWN;
                case MovementDirections.DOWN:return MovementDirections.LEFT;
                case MovementDirections.LEFT:return MovementDirections.UP;
                default:return MovementDirections.RIGHT;
            }  
        }
        private MovementDirections GetDirectionToTheLeft(MovementDirections direction)
        {
            switch (direction)
            {
                case MovementDirections.None: return MovementDirections.LEFT;
                case MovementDirections.UP: return MovementDirections.LEFT;
                case MovementDirections.RIGHT: return MovementDirections.UP;
                case MovementDirections.DOWN: return MovementDirections.RIGHT;
                case MovementDirections.LEFT: return MovementDirections.DOWN;
                default: return MovementDirections.LEFT;
            }
        }
        #endregion
    }
}