using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class RunningButton : ColorButton
    {
        #region UNITY METHODS
        protected override void Start()
        {
            currentTarget = points.GetObject(0).position;
            agent.Warp(currentTarget);
            agent.SetDestination(currentTarget);
            warpable.OnWarp = (surface) =>
            {
                agent.SetDestination(currentTarget);
            };
        }

        protected override void Update()
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
        [SerializeField] private WarpableObject warpable;
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
        protected override int ChooseWall()
        {
            return base.ChooseWall();
        }
        #endregion
    }
}