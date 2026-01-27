using System;
using UnityEngine;

namespace Entrance.Games.Demos
{
    public class MovibleElement : MonoBehaviour
    {
        public float velocity;
        public Vector3 targetPos;
        public Action OnTargetReached;
        public Switch switchManager;

        private void Start()
        {
            OnTargetReached += () =>
            {
                SetNewPosition(switchManager.GetRandomPoint());
            };
            SetNewPosition(switchManager.GetRandomPoint());
        }

        private void Update()
        {
            if (targetPos == null) { return; }

            transform.position = Vector3.MoveTowards(transform.position, targetPos, velocity * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                OnTargetReached?.Invoke();
            }

        }

        public void SetNewPosition(Vector3 newPos)
        {
            targetPos = newPos;
        }
    }
}