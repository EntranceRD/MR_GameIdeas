using Entrance.Squash;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Demos
{
    public class MovibleElement : MonoBehaviour
    {
        [Range(0, 5f)] public float velocity;
        [SerializeField] private Vector3 targetPos;
        private Vector3 direction;
        [SerializeField, Range(0, 1f)] private float distanceToTarget;

        public List<Transform> targets = new List<Transform>();
        [SerializeField] private SurfacePoints surface;
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
            Debug.Log("Teleporting");
            this.surface = surface;
        }

        public void FindNewTarget()
        {
            Debug.Log("Finding new target");
            if (surface == null) return;
            targetPos = surface.GetRandomPoint().position;
            direction= (targetPos - transform.position).normalized;
        }

        public void SetNewTargetList(List<Transform> newTargetList)
        {
            targets.Clear(); targets.AddRange(newTargetList);
        }
        //private void SetNewTarget()
        //{
        //    var randIndex= UnityEngine.Random.Range(0, targets.Count);
        //    targetPosIndex = randIndex;
        //    targetPos = targets[randIndex].position;
        //}
    }
}