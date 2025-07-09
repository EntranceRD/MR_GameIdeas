using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class RandomAngleGenerator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            if (!debug) { return; }
            if (Input.GetKeyDown(KeyCode.Return)) {
                //GetRandomDirection(relativeOrientation);
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private bool debug = false;
        [SerializeField] private Transform relativeOrientation;
        [SerializeField]
        public int minAngle = 0;
        [SerializeField]
        public int maxAngle = 0;
        #endregion

        #region PUBLIC METHODS
        public Vector3 GetRandomDirection(Transform relative = null)
        {
            var angle = GetRandomAngleInRange();
            if (debug) { 
            Debug.Log($"Random Angle [{minAngle} , {maxAngle}] is {angle}");
            }
            var direction = Quaternion.Euler(0, 0, angle) * Vector3.right;

            //var dif = Vector3.Angle(Vector3.right, relative.forward);

            return direction;
            //return relative == null ? direction : relative.TransformDirection(direction);
        }
        #endregion

        #region PRIVATE METHODS
        private int GetRandomAngleInRange()
        {
            return Random.Range(minAngle, maxAngle);
        }
        #endregion
    }
}