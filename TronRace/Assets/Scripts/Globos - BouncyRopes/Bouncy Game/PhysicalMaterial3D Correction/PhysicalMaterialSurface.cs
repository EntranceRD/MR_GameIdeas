using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PhysicalMaterialSurface : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var obj = other.GetComponent<PhysicalMaterialObejct>();
            if (obj != null) {
                obj.SetMaterialBounciness(bounciness);
                //Debug.Log($"Set Bouncines of object {other.transform.name} to {bounciness}");
            }
        }

        private void Start()
        {

        }
        #endregion

        #region VARIABLES
        [SerializeField, Range(0, 2)] private float bounciness = 1;
        #endregion

        #region PUBLIC METHODS
        public void SetBounciness(float bounciness)
        {
            this.bounciness = bounciness;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}