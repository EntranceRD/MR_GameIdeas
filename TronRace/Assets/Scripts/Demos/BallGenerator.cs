using Entrance;
using Entrance.Games.Demos;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    #region UNITY METHODS
    #endregion

    #region VARIABLES
    [SerializeField] private List<SpawnPosition> instancePoints = new List<SpawnPosition>();
    [SerializeField] private ObjectInstantiator instantiator;
    public int ballsPerGame;
    public GameObject ballPrefab;
    public ObjectPool objPool;
    #endregion

    #region PUBLIC METHODS
    public void Restart()
    {
        instantiator.Restart();
        InstantiateBall();
    }
    #endregion

    #region PRIVATE METHODS
    private void InstantiateBall()
    {
        for (int i = 0; i < ballsPerGame; i++)
        {
            var position = GetRandomPosition();
            if (position != null)
            {
                instantiator.ObjectPrefab = ballPrefab;
                var newBall = instantiator.Instantiate(position);
            }
        }
    }

    private Transform GetRandomPosition()
    {
        var randomIndex = Random.Range(0, instancePoints.Count);
        return instancePoints[randomIndex].gameObject.transform;
    }
    #endregion
}