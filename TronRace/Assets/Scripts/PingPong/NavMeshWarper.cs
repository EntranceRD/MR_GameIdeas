using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class NavMeshWarper : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var obj = other.GetComponent<WarpableObject>();
            //var agent = other.GetComponent<NavMeshAgent>();
            if (obj != null) {
                obj.Warp(exit.position, exit);

                //codigo para botón de secuencia que se mueve entre paredes

                //agent.isStopped = true;
                //agent.Warp(exit.position);
                //agent.transform.rotation = exit.rotation;
                //agent.GetComponent<RunningButton>().ResetPath();
                //agent.isStopped = false;
            }
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private Transform exit;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}