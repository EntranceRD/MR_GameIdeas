using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class MultiTargetGame : MonoBehaviour, IRestartable
    {
        #region UNITY METHODS
        public void Start()
        {
            if (targets == null) return;

            foreach (var target in targets)
            {
                target.action = () =>
                {
                    ChangeObjectives();
                    //target.SetObjective(targetPositions.GetRandomObject());
                };
            }
        }
        #endregion


        #region VARIABLES
        public Target[] targets;

        [SerializeField]
        private ObjectGroup<Transform> targetPositions;
        private List<Transform> targetSpawnPositions = new List<Transform>();
        #endregion

        #region PUBLIC METHODS
        public void ChangeObjectives()
        {
            if (targets == null) return;
            CalculatePositions();

            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].SetObjective(targetSpawnPositions[i]);
            }
            //foreach (var target in targets)
            //{
            //    target.SetObjective(targetPositions.GetRandomObject());
            //}
        }
        public void SetTargets(Target[]_targets) {
            targets = _targets;
        }
        public void Restart() {
            ChangeObjectives();
        }
        #endregion

        #region PRIVATE METHODS
        private void CalculatePositions() {
            targetSpawnPositions.Clear();
            targetSpawnPositions.Add(targetPositions.GetRandomObject());
            int i = 0;

            while(targetSpawnPositions.Count <targets.Length && i<100)
            {
                var newObjective = targetPositions.GetRandomObject();
                if (isSpawnPointValid(newObjective)) {
                    targetSpawnPositions.Add(newObjective);
                    ++i;
                }
            }
        }
        private bool isSpawnPointValid(Transform spawn) {
            foreach (var knownPoint in targetSpawnPositions) {
                var dist = Vector3.Distance(knownPoint.position, spawn.position);
                if (dist < 0.1f) return false;
            }
            return true;
        }
        #endregion
    }
}