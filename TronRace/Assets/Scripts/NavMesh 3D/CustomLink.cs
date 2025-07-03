using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class CustomLink : MonoBehaviour
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
        [Tooltip("The exit point must have an adapted surface normal.")]
        [SerializeField] private Transform exitPoint;

        [SerializeField] private SurfacePortal portal;
        [SerializeField] private bool ChangeDirection = false;
        [SerializeField] private MovementDirections direction = MovementDirections.UP;
        #endregion

        #region PUBLIC 
        public bool InvertX() { return portal.InvertX; }
        public Transform GetExitNormals() {
            if (portal == null) { return exitPoint; }
            return portal.newSurfaceNormals; 
        }
        public void Setup(SurfacePortal portalRef) {
        //public void Setup(SurfacePortal portalRef) {
            portal = portalRef;
            ChangeDirection = portalRef.changeDirection;
            direction = portalRef.exitDirection;
        }
        public Transform GetExitPoint()
        {
            return exitPoint;
        }
        public void ChangeTravelerDirection(Navmeshable_Traveler traveler) {
            if (!ChangeDirection) return;
            traveler.SetMovement(direction);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}