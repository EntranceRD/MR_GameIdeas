using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class BounceMaterial : MonoBehaviour
    {
        #region UNITY METHODS
        void OnCollisionEnter(Collision collision)
        {
                Vector3 normal = collision.contacts[0].normal;

            Vector3 reflectedVelocity = Vector3.Reflect(rb.velocity, normal);
            //Vector3 reflectedVelocity = Vector3.Reflect(collision.relativeVelocity, normal);
            //Vector3 reflectedVelocity = Vector3.Reflect(collision.relativeVelocity, normal);
            Debug.Log($"reflected vel: {reflectedVelocity}");
            Debug.Log("Coll ision vel:  "+collision.relativeVelocity);

            if (bounciness < 1)
            {
                manual_bounceMat.bounciness = 0.972f * (bounciness);
            }
            else {
                manual_bounceMat.bounciness = .972f;
            rb.AddForce(collision.relativeVelocity.normalized * (bounciness-1f), ForceMode.Impulse);
            }
            GetComponent<Collider>().material = manual_bounceMat;
            //rb.velocity = newVelocity;
        }
        private void Start()
        {
            manual_bounceMat = new PhysicMaterial();
            manual_bounceMat.bounciness = 0;
            manual_bounceMat.bounceCombine = PhysicMaterialCombine.Maximum;
            manual_bounceMat.dynamicFriction = 0;
            manual_bounceMat.staticFriction = 0;
            manual_bounceMat.frictionCombine =  PhysicMaterialCombine.Minimum;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                bounceMat.bounciness = 2;
                //bounceMat.bouncyness = 2;
                bounceMat.bounceCombine =  PhysicMaterialCombine.Maximum;
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField, Range(0, 20)] private float bounciness=1;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private PhysicMaterial bounceMat;
        [SerializeField] private PhysicMaterial manual_bounceMat;
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