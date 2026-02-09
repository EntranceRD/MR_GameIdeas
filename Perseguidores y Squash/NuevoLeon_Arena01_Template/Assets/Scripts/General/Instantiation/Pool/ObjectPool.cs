using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ObjectPool
    {
        #region CONSTRUCTORS
        public ObjectPool()
        {
            inactiveObjects = new Queue<PoolableObject>();
        }
        #endregion

        #region VARIABLES
        private Queue<PoolableObject> inactiveObjects;
        #endregion

        #region PUBLIC METHODS
        public void Initialize(List<PoolableObject> objects) {
            for (int i = 0; i < objects.Count; ++i)
                SetupObjectForPoolOnRecycle(objects[i]);
        }
        public void SetupObjectForPoolOnRecycle(PoolableObject obj) {
            obj.OnRecycle.AddAction(() =>
            {
                inactiveObjects.Enqueue(obj);
            });
        }
        public PoolableObject GetObject()
        {
            if (inactiveObjects.Count == 0) return null;
            //var obj = inactiveObjects.Dequeue();
            return inactiveObjects.Dequeue();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}