using Entrance.Games.Mathematics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entrance.Games.Coins 
{
    public class Ranking : MonoBehaviour
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
        [SerializeField] private Dictionary<int, int> ranking = new Dictionary<int, int>();
        [SerializeField] private RankingDisplayer displayer;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            ranking.Clear();
            displayer.Restart();
        }

        public void ShowRanking(Dictionary<int, int> data)
        {
            var orderedRanking = data.OrderByDescending(pair => pair.Value).ToList();
            displayer.DisplayIntValues(orderedRanking);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}