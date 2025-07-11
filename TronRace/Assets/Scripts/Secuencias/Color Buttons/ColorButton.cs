using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ColorButton : MonoBehaviour
    {
        #region UNITY METHODS
        protected virtual void Start()
        {
        }

        protected virtual void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Return)) {
            //    ChangePosition();
            //}
        }
        #endregion

        #region VARIABLES
        public int SequenceValue = -1;
        [SerializeField] protected ObjectGroup<SpawnPoint> rightWall;
        [SerializeField] protected ObjectGroup<SpawnPoint> leftWall;
        [SerializeField] protected ObjectGroup<SpawnPoint> frontWall;
        public int SpawnedWall { get; protected set; } = -1;
        public SpawnPoint spawnPoint;
        #endregion

        #region PUBLIC METHODS
        public void FreeSpawn() {
            if (spawnPoint == null) return;
            spawnPoint.isFree = true;
        }
        public virtual void ChangePosition() {
            SpawnedWall = ChooseWall();
            SpawnPoint point = null;
            switch (SpawnedWall)
            {
                case 0: point = GetSpawnPoint(rightWall); break;
                case 1: point = GetSpawnPoint(leftWall); break;
                case 2: point = GetSpawnPoint(frontWall); break;
                default:return;
            }
            spawnPoint = point;
            spawnPoint.isFree = false;
            transform.position = point.transform.position;
        }
        #endregion

        #region PRIVATE METHODS
        protected virtual int ChooseWall() { return -1; }

        protected SpawnPoint GetSpawnPoint(ObjectGroup<SpawnPoint> surface)
        {
            for (int i = 0; i < 20; i++)
            {
                var point = surface.GetRandomObject();
                if (point.isFree) { return point; }
            }
            return null;
            //return surface.GetRandomObject();
        }
        #endregion
    }
}