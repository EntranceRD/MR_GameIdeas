using Entrance.Squash;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Movible
{
    public class MovibleElement : MonoBehaviour
    {
        [SerializeField] private SurfacePoints surface;
        [SerializeField,Range(0, 5f)] private float velocity;
        [SerializeField] private Vector3 targetPos;
        [SerializeField, Range(0, 1f)] private float distanceToTarget;
        private Vector3 direction;
        public Action OnTargetReached;

        private void Start()
        {
            //if (targets != null && targets.Count > 1) 
            //{
            //SetNewTarget();
            //}
            OnTargetReached -= FindNewTarget;
            OnTargetReached += FindNewTarget;

            FindNewTarget();
        }

        void Update()
        {
            if (targetPos == null) { return; }

            transform.position += direction * velocity * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, targetPos, velocity * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < distanceToTarget)
            {
                OnTargetReached?.Invoke();
            }
        }

        public void Restart()
        {
            surface = null;
            targetPos = Vector3.zero;
            direction = Vector3.zero;
            SetSpeed(0);
        }

        //public void ManualStart(List<Transform> points)
        //{
        //    targets = points;
        //    SetNewTarget();
        //}

        public void SetSpeed(float newSpeed)
        {
            velocity = newSpeed;
        }

        public void SetSurface(SurfacePoints surface)
        {
            this.surface = surface;
        }

        public void FindNewTarget()
        {
            if (surface == null) return;
            targetPos = surface.GetRandomPoint().position;
            direction = (targetPos - transform.position).normalized;
        }
    }
}