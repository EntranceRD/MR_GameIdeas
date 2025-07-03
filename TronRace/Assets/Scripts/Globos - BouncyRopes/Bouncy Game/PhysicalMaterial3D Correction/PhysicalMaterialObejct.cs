using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PhysicalMaterialObejct : MonoBehaviour
    {
        #region UNITY METHODS
        void OnCollisionEnter(Collision collision)
        {
            //Debug.Log($"Entering bounce collision");
            if (bounciness <= 1)
            {
                physicMaterial.bounciness = 0.972f * (bounciness);
            }
            else
            {
                physicMaterial.bounciness = .972f;
                //add force on collision to add more bounce
                rb.AddForce(collision.relativeVelocity.normalized * (bounciness - 1f), ForceMode.Impulse);
            }
        }
        private void Start()
        {
            physicMaterial = new PhysicMaterial();
            physicMaterial.bounciness = .972f;
            physicMaterial.bounceCombine = PhysicMaterialCombine.Maximum;
            physicMaterial.dynamicFriction = 0;
            physicMaterial.staticFriction = 0;
            physicMaterial.frictionCombine = PhysicMaterialCombine.Minimum;

            collision.material = physicMaterial;
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        private PhysicMaterial physicMaterial;
        [SerializeField]private Collider collision;
        [SerializeField]private Rigidbody rb;
        [SerializeField,Range(0,2)]
        private float bounciness=1;
        #endregion

        #region PUBLIC METHODS
        public void SetMaterialBounciness(float bounciness)
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