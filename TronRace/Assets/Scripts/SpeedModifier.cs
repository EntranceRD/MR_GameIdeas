using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class SpeedModifier : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            initialPos = transform.position;
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        private Vector3 initialPos;
        private int step = 0;
        [SerializeField] private AnimationCurve speedEquation;
        [SerializeField] private MovibleElement[] speedDependants;
        #endregion

        #region PUBLIC METHODS
        public void MoveStep(int amount)
        {
            step += amount;
            UpdateSpeedDependants();
        }

        public void Restart()
        {
            step = 0;
            transform.position = initialPos;
            MoveStep(0);
        }
        #endregion

        #region PRIVATE METHODS
        private void UpdateSpeedDependants()
        {
            var speed = speedEquation.Evaluate(step);
            for (int i = 0; i < speedDependants.Length; i++)
            {
                speedDependants[i].SetSpeed(speed);
            }
        }
        #endregion
    }
}