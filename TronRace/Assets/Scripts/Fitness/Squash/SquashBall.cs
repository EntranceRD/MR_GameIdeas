using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Squash 
{
    public class SquashBall : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            teleportable.OnTeleport += (newPoint) =>
            {
                movible.FindNewTarget();
            };
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Teleport.TeleportableObject teleportable;
        [SerializeField] private MovibleElement movible;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
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