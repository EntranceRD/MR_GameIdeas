using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class TronDirectionReference : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            traveler.OnDirectionChange += (dir) =>
            {
                Debug.Log($"Changing direction to {dir}");
                currentAngle += isNewDirectionToTheRight(dir)?-90:90;
                var angle = 0;
                switch (dir)
                {
                    case MovementDirections.DOWN: angle = -180; break;
                    case MovementDirections.UP: angle = 0; break;
                    //case MovementDirections.LEFT:angle = traveler.hasInvertedX?90: -90;break;
                    //case MovementDirections.RIGHT:angle = traveler.hasInvertedX? -90:90;break;           
                    case MovementDirections.LEFT: angle = 90; break;
                    case MovementDirections.RIGHT: angle = -90; break;
                }
                //var rot = new Vector3(0, 0, angle);
                var rot = new Vector3(0, 0, currentAngle);
                arrow.localRotation = Quaternion.Euler(rot);
            };
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private RectTransform arrow;
        [SerializeField]
        private Navmeshable_Traveler traveler;
        private MovementDirections prevDirection = MovementDirections.UP;
        private int currentAngle = 0;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private bool isNewDirectionToTheRight(MovementDirections newDir)
        {
            switch (prevDirection) {
                case MovementDirections.UP:return newDir == MovementDirections.RIGHT;
                case MovementDirections.DOWN:return newDir == MovementDirections.LEFT;
                case MovementDirections.RIGHT:return newDir == MovementDirections.DOWN;
                case MovementDirections.LEFT:return newDir == MovementDirections.UP;
                default: return false;
            }
        }
        #endregion
    }
}