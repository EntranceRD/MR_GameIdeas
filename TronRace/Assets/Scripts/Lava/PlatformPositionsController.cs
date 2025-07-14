using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PlatformPositionsController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public static PlatformPositionsController Instance;
        [SerializeField] private ObjectGroup<InstancePointGroup> instancePoints;
        #endregion

        #region PUBLIC METHODS
        public Transform GetRandomPoint()
        {
            return instancePoints.GetRandomObject().GetRandomPoint();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}