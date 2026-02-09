using Entrance.General;
using Entrance.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class FakeClicker : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z)) {
                areaClick = !areaClick;
            }
            if (permaClick||Input.GetKey(KeyCode.Space)) {
                if (!areaClick)
                {
                    CreateClick(transform.position, transform.forward);
                }
                else {
                    Vector3 offset = Vector3.zero;
                    for (int i = -5; i < 5; i++)
                    {
                        //50 cm
                        offset.x = i * 0.05f;
                        //2 metros
                        //offset.x = i * 0.2f;
                        for (int j = -5; j < 5; j++)
                        {
                            offset.z = j * 0.05f;
                            //offset.z = j * 0.2f;
                            CreateClick(transform.position+offset, transform.forward);

                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.X)) {
                permaClick = !permaClick;
            }
        }
        #endregion

        #region VARIABLES
        private bool areaClick = false;
        private bool permaClick = false;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void CreateClick(Vector3 position, Vector3 direction)
        {
                var pos = position;
                Debug.DrawLine(pos, pos + (direction * 30), Color.yellow);
                RaycastHit hit;
                if (Physics.Raycast(pos, direction, out hit, 30))
                //if (Physics.Raycast(point, direction, out hit, 30))
                {
                //Debug.Log($"Creating Click at {position}");
                    CreatePointInteraction(hit);
                }
        }
        private void CreatePointInteraction(RaycastHit hit)
        {
            var pos = new Vec3(hit.point.x, hit.point.y, hit.point.z);
            var interactible = hit.collider.GetComponent<IInteractible>();
            if (interactible != null)
                interactible.Interact(new Entrance.Interaction.Touch(pos));
        }
        #endregion
    }
}