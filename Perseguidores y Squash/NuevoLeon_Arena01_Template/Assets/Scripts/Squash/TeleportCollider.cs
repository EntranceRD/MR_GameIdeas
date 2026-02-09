using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Squash
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
        [SerializeField] private Transform originSurface;
        [SerializeField] private Transform newSurface;
        [SerializeField] private bool preserveX = false;
        [SerializeField] private bool preserveY = false;
        [SerializeField] private bool preserveZ = false;
        #endregion

        #region PUBLIC METHODS
        //public void Teleport(Transform spawnPoint, Transform newWall, BounceBall ball)
        //{
        //    ball.SetOrientation(newWall);
        //    ball.RecalculateDirection();
        //    ball.transform.position = new Vector3(spawnPoint.position.x, ball.transform.position.y, spawnPoint.position.z);
        //    ball.RecalculateVelocity(false);
        //}
        #endregion

        #region PRIVATE METHODS
        private Vector3 GetNewSpawnPointForObject(Transform obj) {
            var position = newSurface.position;
            if (preserveX) { position.x = obj.position.x; }
            if (preserveY) { position.y = obj.position.y; }
            if (preserveZ) { position.z = obj.position.z; }
            return position;
        }
        #endregion

    }

}