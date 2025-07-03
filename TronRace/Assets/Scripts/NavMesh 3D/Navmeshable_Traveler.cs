using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Entrance 
{
    public class Navmeshable_Traveler : MonoBehaviour
    {
        #region UNITY METHODS
        protected virtual void Start()
        {
            SetSurfaceNormals(startingSurface, true);
        }

        protected virtual void Update()
        {
            if (!canMove) { return; }
            inputDirection = MovementDirections.None;
            //CheckMovementInputs();
            SetDirectionAccordingToLastValidData();
            agent.Move( direction * speed * Time.deltaTime);
        }
        protected virtual void LateUpdate() {
            //Debug.Log($"Wants to change direction from {movingDirection} to {inputDirection}");
            if (inputDirection == MovementDirections.None) { return; }
            if (movingDirection == inputDirection) { return; }
            OnDirectionChange?.Invoke(inputDirection);
            movingDirection = inputDirection;
            inputDirection = MovementDirections.None;
        }
        #endregion

        #region VARIABLES
        public bool canMove = true;
        public bool hasInvertedX { get; private set; } = true;
        [SerializeField, Range(0, 5)] protected float speed = 1;
        [SerializeField] private Transform startingSurface;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] public Transform startPosition;
        private Vector3 direction = Vector3.zero;
        private Vector3 up = Vector3.zero;
        private Vector3 right = Vector3.zero;
        public MovementDirections movingDirection { get; protected set; } = MovementDirections.None; //last valid direction
        protected MovementDirections inputDirection = MovementDirections.None;

        public System.Action<MovementDirections> OnDirectionChange;
        #endregion

        #region PUBLIC METHODS
        public void Restart() {
            agent.Warp(startPosition.position);
            movingDirection = MovementDirections.None;
            inputDirection = MovementDirections.None;
            SetSurfaceNormals(startingSurface, true);
        }
        public void SetMovement(MovementDirections direction) {
            //Debug.Log($"Set movement to: {direction}");
            inputDirection = direction;
            movingDirection = direction;
            OnDirectionChange?.Invoke(direction);
        }
        public void SetSurfaceNormals(Transform surface, bool inverted = false)
        {
            right = inverted ? surface.right * -1 : surface.right;
            up = surface.up;
            hasInvertedX = inverted;
        }
        public void StartMovement(MovementDirections movementDirection) {
            inputDirection |= movementDirection; 
        }
        public void StopMovement() {
            canMove = false;
            movingDirection = MovementDirections.None;
            direction = Vector3.zero;
        }
        #endregion

        #region PRIVATE METHODS
        private void CheckMovementInputs()
        {
            if (Input.GetKey(KeyCode.W)) { StartMovement(MovementDirections.UP); }
            if (Input.GetKey(KeyCode.S)) { StartMovement(MovementDirections.DOWN); }
            if (Input.GetKey(KeyCode.D)) { StartMovement(MovementDirections.RIGHT); }
            if (Input.GetKey(KeyCode.A)) { StartMovement(MovementDirections.LEFT); }
        }
        private void SetDirectionAccordingToLastValidData() {
            if ((movingDirection & MovementDirections.UP) != 0) { direction += up; }
            if ((movingDirection & MovementDirections.DOWN) != 0) { direction -= up; }
            if ((movingDirection & MovementDirections.RIGHT) != 0) { direction += right; }
            if ((movingDirection & MovementDirections.LEFT) != 0) { direction -= right; }
            direction.Normalize();
        }
        #endregion
    }
}