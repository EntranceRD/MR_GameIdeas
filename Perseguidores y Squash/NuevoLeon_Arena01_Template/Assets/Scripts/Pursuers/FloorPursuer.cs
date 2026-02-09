using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Pursuers
{
    public class FloorPursuer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if (!pursuing) return;
            if (target.magnitude>50) return;
            if (target.magnitude < 0.1f) return;

            var dist = Vector3.Distance(target, transform.position);
            if (dist <= 0.05f) { return; }
            transform.position += dir * Time.deltaTime * speed * speedMultiplier;
        }
        #endregion

        #region VARIABLES
        public bool pursuing = false;
        [SerializeField, Range(0, 5)] private float speed = 0.5f;
        private float speedMultiplier = 1f;

        private Vector3 dir;
        private Vector3 target;
        private Collider col;
        public System.Action OnPlayerCapture;
        #endregion

        #region PUBLIC METHODS
        public void SetPosition(Vector3 position) { transform.position = position; }
        public void Initialize() {
            if (pursuing) { return; }
            if (col == null) { 
                col = GetComponent<Collider>();
            }
        }

        public void Activate() {
            if (pursuing) { return; }
            pursuing = true; 
            col.enabled = true;
            target.x =100;
        }
        public void Deactivate() { 
            if (!pursuing) { return; }
            pursuing = false; 
            col.enabled = false; 
        }

        public void SetTarget(Vector3 position)
        {
            if (position.magnitude < 0.1f) return;

            target = position;
            dir = (target - transform.position).normalized;
        }
        public void SetSpeedMultiplier(float multiplier) { speedMultiplier = multiplier; }
        public void CapturePlayer() { OnPlayerCapture?.Invoke(); }
        #endregion

        #region PRIVATE METHODS
        //private void Set
        #endregion
    }
}