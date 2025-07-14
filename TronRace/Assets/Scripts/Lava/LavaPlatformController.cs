using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class LavaPlatformController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            instanceTime.OnFinish = () => {
                InstantiateNewRoundOfPlatforms();
                instanceTime.Restart();
            };
            InstantiateNewRoundOfPlatforms();

            instanceTime.Restart();
        }

        private void Update()
        {
            instanceTime.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ObjectInstantiator instantiator;
        [SerializeField]
        private ObjectGroup<Transform> instancePoints;
        [SerializeField] private Timer instanceTime;
        [SerializeField, Range(1, 4)] private int users = 4;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void InstantiateNewRoundOfPlatforms()
        {
            for (int i = 0; i < users; i++)
            {
                var pos = instancePoints.GetObject(i);
                instantiator.Instantiate(pos);
            }
        }
        #endregion
    }
}