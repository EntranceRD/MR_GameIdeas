using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Demos
{
    public class BounceBall : MonoBehaviour
    {
        //private float speed = 0f;
        public float angle = 1f;
        public Rigidbody rb;
        public Transform orientationReference;

        private void Start()
        {
            rb=transform.GetComponent<Rigidbody>();
            Physics.gravity= new Vector3   (0,-.3f,0);
            //SetVelocity(orientationReference.right *.5f);
            //angle= Random.Range(-30,-150);
            //RecalculateMovement();

        }
        private void Update()
        {
            //if (Input.GetKey(KeyCode.UpArrow)) { 
            //     angle += 60*Time.deltaTime;
            //    RecalculateDirection();
            //}
            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    angle -= 60 * Time.deltaTime;
            //    RecalculateDirection();
            //}
            ///REBOTE
            if (Input.GetKeyDown(KeyCode.LeftArrow)) { 
                angle = 180 -angle;
                RecalculateDirection();
                RecalculateVelocity(false);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                angle = 180 - angle;
                RecalculateDirection();
                RecalculateVelocity(false);
            }
            ///CLICK / IMPULSO
            if (Input.GetKeyDown(KeyCode.W)) {
                angle = Random.Range(30, 150);
                RecalculateDirection();
                Impulse(1);
            }

        }
        public void SetOrientation(Transform reference) { 
            orientationReference = reference;
            transform.parent = orientationReference;
        }
        public void RecalculateDirection() {
            //var speed=rb.velocity.magnitude;
            //rb.velocity = Vector3.zero;
            transform.localRotation = Quaternion.Euler(0, 0, angle);
            //SetVelocity(transform.right * speed);
        }
        public void RecalculateVelocity(bool invertY) {
            var speed = rb.velocity.magnitude;
            var y = rb.velocity.y;
            var vel = transform.right * speed;
            vel.y = invertY ? -y:y ;
            SetVelocity(vel);

        }
        public void Impulse(float speed) {
            rb.velocity = Vector3.zero;
            rb.angularVelocity= Vector3.zero;
            SetVelocity(transform.right * speed);
        }
        private void SetVelocity(Vector3 velocity) {
            rb.velocity = velocity;
        }
    }
}