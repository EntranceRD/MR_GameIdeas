using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class RunningButton : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            currentTarget = points.GetObject(0).position;
            agent.Warp(currentTarget);
            agent.SetDestination(currentTarget);
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, currentTarget);
            if (dist < minDistance)
            {
                currentTargetIndex = (currentTargetIndex + 1) % points.objects.Count;
                currentTarget = points.GetObject(currentTargetIndex).position;
                agent.SetDestination(currentTarget);
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private ObjectGroup<Transform> points;
        [SerializeField, Range(0, 1)]
        private float minDistance = 0.1f;
        [SerializeField]
        private NavMeshAgent agent;
        private Vector3 currentTarget;
        private int currentTargetIndex = 0;
        #endregion

        #region PUBLIC METHODS
        public void ResetPath()
        {
            agent.SetDestination(currentTarget);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}