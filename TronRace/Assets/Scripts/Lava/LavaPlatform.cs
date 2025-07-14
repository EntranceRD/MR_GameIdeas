using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class LavaPlatform : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            //SetNewDirection();
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, currentTarget);
            if (dist <= 0.2f) {
                SetNewDirection();
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private NavMeshAgent agent;
        private Vector3 currentTarget = Vector3.zero;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            SetNewDirection();
        }
        #endregion

        #region PRIVATE METHODS
        private void SetNewDirection()
        {
            var pos = PlatformPositionsController.Instance.GetRandomPoint().position;
            currentTarget = pos;
            agent.SetDestination(pos);
        }
        #endregion
    }
}