using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class InstancePointGroup : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public ObjectGroup<Transform> instancePoints;
        #endregion

        #region PUBLIC METHODS
        public Transform GetPoint(int index)
        {
            return instancePoints.GetObject(index);
        }
        public Transform GetRandomPoint()
        {
            return instancePoints.GetRandomObject();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}