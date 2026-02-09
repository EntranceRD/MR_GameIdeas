using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public sealed class ObjectGroup<T> where T : class
    {
        #region CONSTRUCTORS
        public ObjectGroup()
        {
            objects = new List<T>();
        }
        #endregion

        #region VARIABLES
        public List<T> objects;
        //private int lastIndex = -1;
        #endregion

        #region PUBLIC METHODS
        public T GetObject(int index)
        {
            index = Mathf.Clamp(index,0, objects.Count);
            return objects[index];
        }
        public T GetRandomObject()
        {
            int random = Random.Range(0, objects.Count);
            return GetObject(random);
        }
        public void SimpleIteration(System.Action<T> OnIteration) {
            foreach (var obj in objects)
            {
                if (obj != null) { 
                    OnIteration?.Invoke(obj);
                }
            }
        }
        public void AddRange(params T[] items) {
            foreach (var item in items) {
                if (item != null) { objects.Add(item); }
            }
        }
        public void Add(T item) {
            if (item == null) return;
            objects.Add(item);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}