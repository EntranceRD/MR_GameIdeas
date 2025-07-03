using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class AutomaticObjectInstantiator:ObjectInstantiator
    {
        #region CONSTRUCTORS
        public AutomaticObjectInstantiator()
        {
            instancePoints = new ObjectGroup<Transform>();
            instanceTime = new Timer() {
                Target = 1f,
                OnFinish = () => {
                    var point = instancePoints.GetRandomObject();
                    Instantiate(point);
                    instanceTime.Restart();
                }
            };

        }
        #endregion

        #region VARIABLES
        public Timer instanceTime;
        public ObjectGroup<Transform> instancePoints;
        #endregion

        #region PUBLIC METHODS
        public void Start()
        {
            instanceTime.Restart();
        }
        public void Update(float deltaTime)
        {
            instanceTime.Tick(deltaTime);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}