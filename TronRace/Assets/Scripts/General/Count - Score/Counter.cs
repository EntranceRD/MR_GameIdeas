using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class Counter
    {
        #region CONSTRUCTORS
        public Counter()
        {
            
        }
        public static implicit operator int(Counter c) => c.count;
        #endregion

        #region VARIABLES
        private int count = 0;
        #endregion

        #region PUBLIC METHODS
        public void Add() { Add(1); }
        public void Add(int amount) { count += amount; }
        public void Restart() { count = 0; }
        #endregion

    }
}