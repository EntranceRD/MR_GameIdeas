using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class ObjectInstantiator
    {
        #region CONSTRUCTORS
        public ObjectInstantiator()
        {
            inactiveObjects = new ObjectPool();
            createdObjects = new List<PoolableObject>();
        }
        #endregion

        #region VARIABLES
        public GameObject ObjectPrefab;

        private ObjectPool inactiveObjects;
        private List<PoolableObject> createdObjects;
        #endregion

        #region PUBLIC METHODS
        public Transform Instantiate(Transform point)
        {
            var obj = inactiveObjects.GetObject();
            if (obj == null||obj.active) {
                obj = InstantiateNewObject();
            }
            if (obj == null) { 
                return null;
            }

            obj.transform.position = point.position;
            obj.transform.rotation = point.rotation;
            obj.Activate();
            return obj.transform;
        }
        public void Restart() {
            for (int i = 0; i < createdObjects.Count; ++i)
                createdObjects[i].Recycle();
        }
        #endregion

        #region PRIVATE METHODS
        private PoolableObject InstantiateNewObject()
        {
            if (ObjectPrefab == null) return null;

            var obj = Object.Instantiate(ObjectPrefab);
            return InitializeNewObject(obj);
        }
        private PoolableObject InitializeNewObject(GameObject obj) {
            var poolable = obj.GetComponent<PoolableObject>();
            if (poolable == null)
                poolable = obj.AddComponent<PoolableObject>();

            inactiveObjects.SetupObjectForPoolOnRecycle(poolable);
            createdObjects.Add(poolable);
            return poolable;
        }
        #endregion
    }
}