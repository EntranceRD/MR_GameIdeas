using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Entrance.Games.Sequence
{
    public class Ranking : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            GameManager.Instance.OnGameStop -= DisplayRanking;
            GameManager.Instance.OnGameStop += DisplayRanking;
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        [SerializeField] private ColorBoard[] colorBoards;
        [SerializeField] private Dictionary<int, int> boardsRank = new Dictionary<int, int>();
        [SerializeField] private RankingDisplayer rankingDisplayer;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            rankingDisplayer.Restart();
            boardsRank.Clear();
        }

        public void DisplayRanking()
        {
            CollectPointsAndDisplay();
        }
        
        #endregion

        #region PRIVATE METHODS
        private void CollectPointsAndDisplay()
        {
            for (int i = 0; i < colorBoards.Length; i++)
            {
                boardsRank.Add(i+1, colorBoards[i].scoreManager.currentPoints);
            }
            var orderedBoards = boardsRank.OrderByDescending(pair => pair.Value).ToList();
            rankingDisplayer.Display(orderedBoards);
        }
        #endregion
    }
}