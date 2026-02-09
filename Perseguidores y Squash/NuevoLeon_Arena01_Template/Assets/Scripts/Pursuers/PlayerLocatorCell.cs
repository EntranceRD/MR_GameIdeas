using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PlayerLocatorCell : MonoBehaviour
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
        [SerializeField] private BoxCollider collider;
        public System.Action<Vector3> OnClick;
        #endregion

        #region PUBLIC METHODS
        public void Initialize(float sizeX, float sizeZ)
        {
            transform.localScale = new Vector3(sizeX, sizeZ, 0.1f);
            collider.size = new Vector3(1, 1, 0.1f);
        }
        public void LocationClick() {
            OnClick?.Invoke(transform.position);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}