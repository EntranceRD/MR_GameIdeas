using System;
using UnityEngine;

namespace Entrance.Games.Demos
{
    public class BounceBall : MonoBehaviour
    {
        //private float speed = 0f;
        public float angle = 1f;
        public Rigidbody rb;
        public Transform orientationReference;
        private Vector3 startPos;
        public Action OnTouch, OnBasket;
        public Color explosionColor;

        private void Awake()
        {
            rb = transform.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Physics.gravity = new Vector3(0, -.3f, 0);
            startPos = transform.position;

            OnTouch += Interaction;
            OnBasket += () =>
            {
                Restart();
            };
        }

        private void Update()
        {

            ///REBOTE
            //if (Input.GetKeyDown(KeyCode.LeftArrow))
            //{
            //    angle = 180 - angle;
            //    RecalculateDirection();
            //    RecalculateVelocity(false);
            //}
            //if (Input.GetKeyDown(KeyCode.RightArrow))
            //{
            //    angle = 180 - angle;
            //    RecalculateDirection();
            //    RecalculateVelocity(false);
            //}
            ///CLICK / IMPULSO
            if (Input.GetKeyDown(KeyCode.W))
            {
                angle = UnityEngine.Random.Range(30, 150);
                RecalculateDirection();
                Impulse(1);
            }
        }

        public void Interaction()
        {
            angle = UnityEngine.Random.Range(30, 150);
            RecalculateDirection();
            Impulse(1);
        }

        public void Restart()
        {
            transform.position = startPos;
            angle = UnityEngine.Random.Range(0, 360);
            RecalculateDirection();
            SetVelocity(Vector3.zero);
            Impulse(0);
        }

        public void SetOrientation(Transform reference)
        {
            orientationReference = reference;
            transform.parent = orientationReference;
        }
        public void RecalculateDirection()
        {
            transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
        public void RecalculateVelocity(bool invertY)
        {
            var speed = rb.velocity.magnitude;
            var y = rb.velocity.y;
            var vel = transform.right * speed;
            vel.y = invertY ? -y : y;
            SetVelocity(vel);

        }
        public void Impulse(float speed)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            SetVelocity(transform.right * speed);
        }
        private void SetVelocity(Vector3 velocity)
        {
            rb.velocity = velocity;
        }
    }
}