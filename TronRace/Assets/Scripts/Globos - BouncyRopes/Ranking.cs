using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entrance.Games
{
    public class TheRanking : MonoBehaviour
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
        [SerializeField] private List<KeyValuePair<int, int>> ranking = new List<KeyValuePair<int, int>>();
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
            ranking = data.OrderByDescending(pair => pair.Value).ToList();
            //displayer.DisplayIntValues(orderedRanking);
            displayer.Display(intData: ranking);
        }

        public void ShowBlueVsRedRanking(Dictionary<TeamColor, int> data)
        {
            var orderedRanking = data.OrderByDescending(pair => pair.Value).ToList();
            displayer.DisplayBlueVsRedValues(orderedRanking);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}