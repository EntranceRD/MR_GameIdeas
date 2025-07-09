using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class WarpableObject : MonoBehaviour
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
        public System.Action<Transform> OnWarp;
        [SerializeField] private NavMeshAgent agent;
        #endregion

        #region PUBLIC METHODS
        public void Warp(Vector3 position, Transform newSurface)
        {
            agent.Warp(position);
            OnWarp?.Invoke(newSurface);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}