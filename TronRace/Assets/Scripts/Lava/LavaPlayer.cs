using Entrance.Interaction;
using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class LavaPlayer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            jumpTime.OnFinish = () => { interactingWithFloor = true; };
        }

        private void Update()
        {
            jumpTime.Tick(Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (interactingWithFloor) { 
                    Jump();
                }
            }
            if (interactingWithFloor) {
                InteractWithFloor();
            }
            var rotMultiplier = 0;
            if (Input.GetKey(KeyCode.A)) { rotMultiplier -= 1; }
            if (Input.GetKey(KeyCode.D)) { rotMultiplier += 1; }
            var rotationAngle = rotMultiplier * rotation * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAngle);
            playerCam.Rotate(Vector3.up, rotationAngle);

            if (Input.GetKey(KeyCode.W)) {
                var dir = transform.forward * Time.deltaTime * speed;
                transform.position += dir;
                playerCam.position += dir;
            }
        }
        #endregion

        #region VARIABLES
        private bool interactingWithFloor = true;
        [SerializeField] private Timer jumpTime;
        [SerializeField] private Transform playerCam;
        [SerializeField,Range(10,180)] private float rotation = 80;
        [SerializeField, Range(0, 2)] private float speed = 1f;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void InteractWithFloor()
        {

            var ray = new Ray(transform.position, Vector3.down);
            Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 5), Color.blue);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 20f))
            {
                //Debug.Log($"obj: {hit.transform.name}");

                var component = hit.transform.GetComponent<IInteractible>();
                if (component != null)
                {
                    component.Interact(new Interaction.Touch(new General.Vec3(hit.point.x,hit.point.y,hit.point.z)));
                }
            }
        }
        private void Jump()
        {
            interactingWithFloor = false;
            jumpTime.Restart();
        }
        #endregion
    }
}