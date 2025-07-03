using Entrance;
using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Squash 
{
    public class SquashBall : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            //Restart();

            hiddenTime.OnFinish = () => {
                ballParent.SetActive(true);
            };
        }

        private void Update()
        {
            var dist = Vector3.Distance(transform.position, nextTarget);
            if (dist < 0.2f)
            {
                var nt = gameArea.GetRandom();
                //Debug.Log($"{transform.name} switching targets to {nt.name}");
                nextTarget = nt.position;
                agent.SetDestination(nextTarget);
            }
        }
        private void FixedUpdate()
        {
            hiddenTime.Tick(Time.fixedDeltaTime);
        }
        #endregion

        #region VARIABLES
        public Transform defaultPosition;
        public SquashGameArea gameArea;
        public NavMeshAgent agent;
        public GameObject ballParent;
        private Vector3 nextTarget;
        public Timer hiddenTime;
        public ButtonEvent OnCaptured;
        #endregion

        #region PUBLIC METHODS
        public void Prepare() {
            agent.speed = 0;
            agent.enabled = false;
            transform.position = defaultPosition.position;
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        public void Restart() {
            ballParent.SetActive(true);
            agent.enabled = true;
            var nt = gameArea.GetRandom();
            nextTarget = nt.position;
            try
            {
                agent.SetDestination(nextTarget);
            }
            catch (System.Exception) { }
        }
        public void Capture()
        {
            hiddenTime.Restart();
            ballParent.SetActive(false);
            OnCaptured.Call();
        }
        public void SetSpeed(float speed) {
            agent.speed = speed;
        }
        public void Hide() { gameObject.SetActive(false); }
        public void Show() { gameObject.SetActive(true); }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}