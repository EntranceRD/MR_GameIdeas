using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class EdgeCollider3D : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            Deactivate();
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private ObjectGroup< EdgeCollider3D_segment> segments;
        #endregion

        #region PUBLIC METHODS
        public void SetBounciness(float bounciness) {
            segments.SimpleIteration((segment) => {
                segment.SetBounciness(bounciness);
            });
        }
        public void Activate()
        {
            segments.SimpleIteration((segment) => { segment.Activate(); });
        }
        public void Deactivate()
        {
            segments.SimpleIteration((segment) => { segment.Deactivate(); });
        }
        public void SetPoints(Vector3[]points, Vector3 right)
        {
            var max = Mathf.Min(points.Length - 1, segments.objects.Count);
            for (int i = 0; i < max; i++)
            {
                var segment = segments.GetObject(i);
                segment.Setup(points[i], points[i + 1]);
                segment.Activate();
                segment.SetColliderRight(right);
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}