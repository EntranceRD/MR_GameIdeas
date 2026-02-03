using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Demos
{
    public class MovibleElement : MonoBehaviour
    {
        public float velocity;
        public Vector3 targetPos;
        public List<Transform> targets = new List<Transform>();
        public Action OnTargetReached;

        private void Start()
        {
            if (targets != null && targets.Count > 1) 
            {
            SetNewTarget();
            }
            OnTargetReached += SetNewTarget;
        }

        void Update()
        {
            if (targetPos == null) { return; }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, velocity * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                OnTargetReached?.Invoke();
            }
        }

        public void ManualStart(List<Transform> points)
        {
            targets = points;
            SetNewTarget();
        }

        private void SetNewTarget()
        {
            var randIndex= UnityEngine.Random.Range(0, targets.Count);
            targetPos = targets[randIndex].position;
        }
    }
}