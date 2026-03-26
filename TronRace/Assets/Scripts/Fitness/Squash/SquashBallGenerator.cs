using Entrance.Games.Demos;
using Entrance.Instantiation;
using Entrance.Squash;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Squash
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
        [SerializeField] private List<SpawnPosition> instancePoints = new List<SpawnPosition>();
        [SerializeField] private SurfacePoints initialSurfacePoint;
        //public SquashBall ballPrefab;
        [SerializeField] private ColorData[] colors;
        [SerializeField] private PlayerController[] players;
        //[SerializeField] private SquashBall[] balls;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            foreach (var player in players)
            {
                player.Restart();
            }
        }

        public void PreparePlayer(int index)
        {
            var color = colors[index].color;
            var position = instancePoints[index].transform.position;
            players[index].SetupGameStart(color, initialSurfacePoint, position);
        }

        public void ReleasePlayers()
        {
            foreach (var player in players)
            {
                player.ReleaseBalls();
            }
        }

        public void StopPlayers()
        {
            foreach(var player in players)
            {
                player.DiseableBalls();
            }
        }

        public Dictionary<int,int> GetPlayersScores()
        {
            var dictionary = new Dictionary<int,int>();

            for (int i = 0; i < players.Length; i++)
            {
                dictionary.Add(i, players[i].score);
            }
            return dictionary;
        }
        #endregion

        #region PRIVATE METHODS
        #endregion
    }
}