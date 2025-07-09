using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class PingPongBall : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            Restart();
        }

        private void Update()
        {
            agent.SetDestination(movementDirection.position);
            if (Input.GetKeyDown(KeyCode.Return)) {
                BounceRandom(angleGenerator);
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                ChangeMovingDirection();
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private NavMeshAgent agent;
        [SerializeField, Range(0, 10)] private float maxSpeed = 3f;
        [SerializeField, Range(0, 5)] private float initialSpeed = 1f;
        //esto solo es para el reinicio
        [SerializeField] private RandomAngleGenerator angleGenerator;
        [SerializeField] private Transform movementDirection;
        [SerializeField] private Transform movingDirectionParent;
        [SerializeField] private Transform currentWall;
        [SerializeField] private Transform initialPosition;
        private bool isGoingRight = true;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            StartCoroutine(restart());
        }
        public void ChangeMovingDirection() {
            isGoingRight = !isGoingRight;
        }
        public void BounceRandom(RandomAngleGenerator random) {
            var angle = random.GetRandomDirection(currentWall);
            angle.x *= isGoingRight?-1:1;
            var dif = Vector3.SignedAngle(Vector3.right, transform.forward, Vector3.up);
            movementDirection.localPosition = angle;
            movingDirectionParent.rotation = Quaternion.identity;
            movingDirectionParent.Rotate(Vector3.up, dif);
        }
        public void ModifySpeed(float speed) {
            agent.speed = Mathf.Min(agent.speed + speed, maxSpeed);
            agent.speed = Mathf.Max(agent.speed, 0);
            if (agent.speed <= 0.58f) { Restart(); }
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator restart()
        {
            agent.isStopped = true;
            agent.speed = initialSpeed;
            WarpAgent(initialPosition);
            ResetMovementDirection();
            movementDirection.position = initialPosition.position;
            yield return new WaitForSeconds(0.1f);
            BounceRandom(angleGenerator);
            agent.isStopped = false;
        }

        private void ResetMovementDirection() {
            isGoingRight = false;
        }
        private void WarpAgent(Transform point) {
            agent.transform.rotation = point.rotation;
            agent.Warp(point.position);
            agent.SetDestination(point.position);
        }
        #endregion
    }
}