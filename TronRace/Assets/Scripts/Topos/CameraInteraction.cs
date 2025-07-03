using Entrance.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class CameraInteraction : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                gameObject.SetActive(false);
                otherCamera.SetActive(true);
            }
            //if (Input.GetMouseButtonDown(0))
            if (Input.GetMouseButton(0))
            {

                var ray = cam.ScreenPointToRay(Input.mousePosition);
                if (offset != null)
                {
                    ray.origin = offset.position;
                }
                Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 5), Color.green);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 20f))
                {
                    //Debug.Log($"obj: {hit.transform.name}");

                    var component = hit.transform.GetComponent<IInteractible>();
                    if (component != null)
                    {
                        component.Interact(new Interaction.Touch());
                    }
                }
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Camera cam;
        [SerializeField] private Transform offset;
        [SerializeField] private GameObject otherCamera;
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