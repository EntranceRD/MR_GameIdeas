using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class EdgeCollider3D_segment : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            rigidCollider.right = transform.up;
            rigidCollider.up = transform.forward;
            rigidCollider.forward = transform.right;
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Transform triggerCollider;
        [SerializeField] private Transform rigidCollider;
        [SerializeField] private PhysicalMaterialSurface surface;
        private Vector3 forward;
        private Vector3 right;
        #endregion

        #region PUBLIC METHODS
        public void SetBounciness(float bounciness) {
            surface.SetBounciness(bounciness);
        }
        public void SetColliderRight(Vector3 right) {
            //var front = rigidCollider.forward;
            //var up = rigidCollider.up;
            //rigidCollider.up = up;
            this.right = right;
      
            //rigidCollider.forward = forward;
        }
        public void Activate() { gameObject.SetActive(true); }
        public void Deactivate() { gameObject.SetActive(false); }
        public void Setup(Vector3 start, Vector3 end)
        {
            transform.position = start;
            var dir = end - start;
            transform.rotation = Quaternion.LookRotation(dir);
            forward = transform.forward;
            var dist = Vector3.Distance(start, end);
            triggerCollider.GetComponent<CapsuleCollider>().height = dist+.1f ;
            var scale = rigidCollider.localScale;
            scale.y = dist;
            rigidCollider.localScale = scale;

            triggerCollider.transform.localPosition =  new Vector3(0,0,1) * ( dist/2f);

            //rigidCollider.right = right;
            //rigidCollider.up = forward;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}