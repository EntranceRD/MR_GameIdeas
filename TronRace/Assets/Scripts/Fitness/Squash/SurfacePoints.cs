using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Squash
{
    public class SurfacePoints : MonoBehaviour
    {
        #region UNITY METHODS
        //private void OnTriggerEnter(Collider other)
        //{
        //    var movibleElement = other.gameObject.GetComponent<MovibleElement>();
        //    if (movibleElement != null)
        //    {
        //        movibleElement.SetSurface(this);
        //        //movibleElement.FindNewTarget();
        //    }
        //}
        private void Awake()
        {
            //surfacePoints = new List<Transform>();
            //exits = new List<Transform>();
            //pointsContainers.AddRange()
            for (int i = 0; i < pointsContainers.objects.Count; i++)
            {
                surfacePoints.AddRange(pointsContainers.GetObject(i).GetComponentsInChildren<Transform>());
            }
            for (int i = 0; i < exitsContainers.objects.Count; i++)
            {
                exits.AddRange(exitsContainers.GetObject(i).GetComponentsInChildren<Transform>());
            }
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        //[SerializeField] private ObjectGroup<Transform> points;
        [SerializeField] private ObjectGroup<Transform> pointsContainers;
        [SerializeField] private ObjectGroup<Transform> surfacePoints;
        [SerializeField] private ObjectGroup<Transform> exitsContainers;
        [SerializeField] private ObjectGroup<Transform> exits;
        private int exitProbability = 0;
        //[SerializeField] private ObjectGroup<Transform> exit_Left;
        //[SerializeField] private ObjectGroup<Transform> exit_Right;
        //[SerializeField] private ObjectGroup<Transform> exit_Top;
        //[SerializeField] private ObjectGroup<Transform> exit_Bottom;
        #endregion

        #region PUBLIC METHODS
        public Transform GetRandomPoint()
        {
            var rand = Random.Range(0f, 100f);
            if(rand <= (85 - exitProbability))
            {
                exitProbability += 10;
                return surfacePoints.GetRandomObject();
            }
            exitProbability = 0;
            return exits.GetRandomObject();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {

        }
        #endregion
    }
}