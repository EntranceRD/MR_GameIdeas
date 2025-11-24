using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ExcavationSite : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            var pos = bottomLeftCorner.position;
            for (int x = 0; x < siteSize.x; x++)
            {
                for (int y = 0; y < siteSize.y; y++)
                {
                    var dirt = instantiator.Instantiate(dirtContainer);
                    dirt.position = pos;
                    dirt.parent = dirtContainer;
                    pos.y += separation.y;
                }
                pos.y = bottomLeftCorner.position.y;
                pos.x += separation.x;
            }
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        [SerializeField] private Transform dirtContainer;
        [SerializeField] private Transform bottomLeftCorner;
        [SerializeField] private Vector2Int siteSize;
        [SerializeField] private Vector2 separation;
        [SerializeField] private ObjectInstantiator instantiator;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}