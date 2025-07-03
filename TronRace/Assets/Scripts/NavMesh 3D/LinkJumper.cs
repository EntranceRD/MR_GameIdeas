using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class LinkJumper : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerStay(Collider other)
        {
            var dist = Vector3.Distance(other.transform.position, transform.position);
            if (dist > 0.35f) return;
            var link = other.GetComponent<CustomLink>();
            if (link == null) return;

            if (!canTeleport) return;
            canTeleport = false;
            disableTeleportTimer.Restart();

            var invertX = link.InvertX();
            //traveler.SetSurfaceNormals(link.GetExitPoint(), true);
            traveler.SetSurfaceNormals(link.GetExitNormals(), invertX);
            JumpTo(link.GetExitPoint());
            link.ChangeTravelerDirection(traveler);
        }
        private void Start()
        {
            disableTeleportTimer.OnFinish = () => { canTeleport = true; };
        }

        private void Update()
        {
            disableTeleportTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        public NavMeshAgent agent;
        public Navmeshable_Traveler traveler;
        private Timer disableTeleportTimer = new Timer() { Target = 1f };
        private bool canTeleport = true;
        #endregion

        #region PUBLIC METHODS
        public void JumpTo(Transform point)
        {
            agent.Warp(point.position);
            //transform.position = point.position;
            //transform.rotation = point.rotation;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}