using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class WeightMap
    {
        #region CONSTRUCTORS
        public WeightMap()
        {
            
        }
        #endregion

        #region VARIABLES
        public bool ForceInitialization = false;
        public ObjectGroup<WeightMapIndex> map;
        private int[] indexes;
        #endregion

        #region PUBLIC METHODS
        public int GetRandomIndex()
        {
            Initialize();
            var rand = Random.Range(0, indexes.Length);
            return indexes[rand];
        }
        #endregion

        #region PRIVATE METHODS
        private void Initialize() {
            if (!shouldInitialize()) return;
           
            indexes = GetIndexesByProbability().ToArray();

            System.Random rnd = new System.Random();
            rnd.Shuffle(indexes);
        }
        private List<int> GetIndexesByProbability() {
            var indexesProbabilityContainer = new List<int>();
            int total = 0;
            foreach (var probability in map.objects)
            {
                total += (int)(20 * probability.weight);
                for (int i = 0; i < total; ++i)
                {
                    indexesProbabilityContainer.Add(probability.index);
                }
            }
            return indexesProbabilityContainer;
        }
        private bool shouldInitialize() {
            if (ForceInitialization) return true;
            //if (indexes != null && indexes.Length > 0) return false;
            return !(indexes != null && indexes.Length > 0);
        }
        #endregion
    }
}