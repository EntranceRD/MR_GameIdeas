using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash 
{
    public class SquashGameArea : MonoBehaviour
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
        [SerializeField] private ObjectGroup<Transform> positions;
        #endregion

        #region PUBLIC METHODS
        public Transform GetRandom()
        {
            return positions.GetRandomObject(); 
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}