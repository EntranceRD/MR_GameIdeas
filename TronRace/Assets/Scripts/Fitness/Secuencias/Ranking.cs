using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        #endregion

        #region VARIABLES
        [Header("References")]
        [SerializeField] private ColorBoard[] colorBoards;
        [SerializeField] private RankingDisplayer rankingDisplayer;

        [Header("Dictionary")]
        [SerializeField] private Dictionary<int, int> boardsRank = new Dictionary<int, int>();
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            rankingDisplayer.Restart();
            boardsRank.Clear();
        }

        public void DisplayRanking()
        {
            boardsRank.Clear();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                boardsRank.Add(i + 1, colorBoards[i].scoreManager.currentPoints);
            }
            var orderedBoards = boardsRank.OrderByDescending(pair => pair.Value).ToList();
            rankingDisplayer.Display(intData: orderedBoards);
        }
        #endregion
    }
}