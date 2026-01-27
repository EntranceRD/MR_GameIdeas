using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ModsGenerator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            instanceTime.OnFinish = () => {
                instanceTime.Restart();
                InstantiateCubes();
            };
            Restart();
            InstantiateCubes();
        }

        private void Update()
        {
            instanceTime.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ObjectGroup<GelatinousPosition> instancePoints;
        [SerializeField] private ObjectInstantiator instantiator;
        [SerializeField] private Timer instanceTime;
        [SerializeField, Range(0, 10)] private int cubesPerInstantiation = 2;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            instantiator.Restart();
            instanceTime.Restart();
        }
        #endregion

        #region PRIVATE METHODS
        private void InstantiateCubes()
        {
            for (int i = 0; i < cubesPerInstantiation; i++)
            {
                var position = GetRandomPosition();
                if (position != null) {
                    var cube = instantiator.Instantiate(position.transform);
                    cube.GetComponentInChildren<GelatinousCube>().SetGelatinousPosition(position);
                    position.free = false;

                    var drop = cube.GetComponentInChildren<GelatinousCubeDrop>();
                    OnGelatinousCubeSpawn(drop);
                }
            }
        }

        private GelatinousPosition GetRandomPosition() {
            for (int i = 0; i < 20; i++)
            {
                var position = instancePoints.GetRandomObject();
                if (position.free) { return position; }
            }
            return null;
        }
        private void OnGelatinousCubeSpawn(GelatinousCubeDrop drop)
        {
            drop.Initialize(ScoreModifier.Instance.GetNewModifier());
        }

        #endregion
    }
}