using Entrance.Games.Demos;
using Entrance.Instantiation;
using Entrance.Squash;
using EntranceGames.Squash;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance
{
    public class SquashBallGenerator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {

        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        [SerializeField] private List<Transform> instancePoints = new List<Transform>();
        [SerializeField] private SurfacePoints initialSurfacePoint;
        public SquashBall ballPrefab;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {

        }

        public SquashBall InstantiateBall()
        {
            var position = GetRandomPosition();
            if (position != null)
            {
                var newBall = Object.Instantiate(ballPrefab);
                newBall.movible.SetSurface(initialSurfacePoint);
                InitializeBall(newBall, position);
                return newBall;
            }
            return null;
        }
        #endregion

        #region PRIVATE METHODS

        private void InitializeBall(SquashBall ball, Transform position)
        {
            ball.transform.position = position.position;
            ball.transform.rotation = position.rotation;
        }

        private Transform GetRandomPosition()
        {
            var randomIndex = Random.Range(0, instancePoints.Count);
            return instancePoints[randomIndex].gameObject.transform;
        }
        #endregion
    }
}