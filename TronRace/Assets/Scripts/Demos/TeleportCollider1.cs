using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Teleport
{
    public class TeleportCollider : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var teleportable = other.gameObject.GetComponent<TeleportableObject>();
            if (teleportable == null) return;

            var spawnPosition = GetNewSpawnPointForObject(teleportable.transform);
            teleportable.Teleport(newSurface, spawnPosition);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Transform newSurface;
        [SerializeField] private bool preserveX = false;
        [SerializeField] private bool preserveY = false;
        [SerializeField] private bool preserveZ = false;
        #endregion

        #region PUBLIC METHODS

        #endregion

        #region PRIVATE METHODS
        private Vector3 GetNewSpawnPointForObject(Transform obj)
        {
            var position = newSurface.position;
            if (preserveX) { position.x = obj.position.x; }
            if (preserveY) { position.y = obj.position.y; }
            if (preserveZ) { position.z = obj.position.z; }
            return position;
        }
        #endregion
    }

}