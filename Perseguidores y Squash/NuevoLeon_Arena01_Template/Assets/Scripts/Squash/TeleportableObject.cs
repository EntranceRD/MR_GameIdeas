using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Squash
{
    public class TeleportableObject : MonoBehaviour
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
        public System.Action<Transform> OnTeleport;
        #endregion

        #region PUBLIC METHODS
        public void Teleport(Transform spawnPoint, Vector3 newPosition)
        {
            Debug.Log($"Teleporting to new position {newPosition}");
            transform.position = newPosition;

            //transform.parent = spawnPoint;
            transform.rotation = spawnPoint.rotation;

            OnTeleport?.Invoke(spawnPoint);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}