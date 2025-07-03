using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class TailGeneration
    {

        #region VARIABLES
        [SerializeField] private GameObject obstaclePrefab;
        [SerializeField] private Transform container;
        [SerializeField] private Material tailColor;

        private ObjectPool tailPool = new ObjectPool();
        private List<PoolableObject> tail = new List<PoolableObject>();
        #endregion

        #region PUBLIC METHODS
        public void RecycleTail()
        {
            foreach (var segment in tail)
            {
                segment.Recycle();
            }
            tail.Clear();
            //instructions.Clear();
        }
        public void SpawnTailSegmentOn(Vector3 position)
        {
            var tailSegment = tailPool.GetObject();
            if (tailSegment == null)
            {
                var segment = InstantiateNewTailSegment();
                SetTailColor(segment);
                tailSegment = segment.GetComponent<PoolableObject>();
                SetupTailSegmentForPool(tailSegment);
                //tail.Add(poolableTail);
            }

            tailSegment.Activate();
            tailSegment.transform.position = position;
            //Debug.Log($"Spawning segment at {position}");
            //tailSegment.transform.rotation = Quaternion.identity;
        }
        #endregion

        #region PRIVATE METHODS
        private GameObject InstantiateNewTailSegment()
        {
            var newObstacle = GameObject.Instantiate(obstaclePrefab, Vector3.zero, Quaternion.identity);
            newObstacle.transform.parent = container;
            return newObstacle;
        }
        private void SetupTailSegmentForPool(PoolableObject segment) {
            tailPool.SetupObjectForPoolOnRecycle(segment);
            segment.OnActivation.AddAction(() =>
            {
                segment.gameObject.SetActive(true);
                tail.Add(segment);
            });
            segment.OnRecycle.AddAction(() =>
            {
                segment.gameObject.SetActive(false);
                //tail.Remove(poolableTail);
            });

        }
        private void SetTailColor(GameObject tailSegment) {   
            var renderer = tailSegment.GetComponent<Renderer>();
            renderer.material = tailColor;
        }
        #endregion
    }
}