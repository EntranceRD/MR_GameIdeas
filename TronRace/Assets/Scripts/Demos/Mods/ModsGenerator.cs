using Entrance.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Demos 
{
    public class ModsGenerator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            instanceTime.OnFinish = () => {
                instanceTime.Restart();
                InstantiateMod();
            };
            Restart();
            InstantiateMod();
        }

        private void Update()
        {
            instanceTime.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private List<Transform> defaultTargetPoints = new List<Transform>();
        [SerializeField] private List<SpawnPosition> instancePoints = new List<SpawnPosition>();
        [SerializeField] private List<GameObject> availableMods = new List<GameObject>();
        [SerializeField] private ObjectInstantiator instantiator;
        [SerializeField] private Timer instanceTime;
        [SerializeField, Range(0, 10)] private int modsPerInstantiation;
        public ObjectPool objPool;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            instantiator.Restart();
            instanceTime.Restart();
        }
        #endregion

        #region PRIVATE METHODS
        private void InstantiateMod()
        {
            for (int i = 0; i < modsPerInstantiation; i++)
            {
                var position = GetRandomPosition();
                var mod = GetRandomMod();
                if (position && mod != null) {
                    instantiator.ObjectPrefab = mod;
                    var newMod = instantiator.Instantiate(position);
                    var movible = newMod.GetComponent<MovibleElement>();
                    if(movible != null )
                    {
                        movible.targets = defaultTargetPoints;
                    }
                }
            }
        }

        private GameObject GetRandomMod()
        {
            var modIndex = Random.Range(0, availableMods.Count);
            return availableMods[modIndex].gameObject;
        }

        private Transform GetRandomPosition() {

            var randomIndex = Random.Range(0, instancePoints.Count);
            return instancePoints[randomIndex].gameObject.transform;
        }
        #endregion
    }
}