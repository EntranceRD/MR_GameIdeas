using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ComplexTargetGameByMaps : MonoBehaviour, IRestartable
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }
        #endregion

        #region VARIABLES
        public Target target;
        public GameObject pseudoTarget;
        public ObjectGroup<Transform> targetPositions; 
        public WeightMap[]map;
        private int currentTargetIndex;
        #endregion

        #region PUBLIC METHODS
        public void MoveTartget()
        {
            pseudoTarget.SetActive(true);
            pseudoTarget.transform.position = target.transform.position;
            currentTargetIndex = map[currentTargetIndex].GetRandomIndex();
            //var pos = targetPositions.GetObject(currentTargetIndex).position;
            //pos.z -= 0.1f;

            //target.transform.position = pos;
            //var obj = targetPositions.GetObject(currentTargetIndex);
            //target.transform.parent = obj;
            //target.transform.localPosition = new Vector3(0, 0, -0.1f);

            var obj = targetPositions.GetObject(currentTargetIndex);
            Vector3 pos = obj.position;
            pos.y -= .1f;
            target.transform.position = pos;
        }
        public void Restart() {
            currentTargetIndex = 0;
            pseudoTarget.SetActive(false);
            var obj = targetPositions.GetObject(currentTargetIndex);
            Vector3 pos = obj.position;
            pos.y -= .1f;
            var namae = targetPositions.GetObject(currentTargetIndex).name;

            //target.transform.parent = obj;
            //target.transform.localPosition = new Vector3(0, 0, -0.1f);

            target.transform.position = pos;
            //target.transform.position = pos;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}