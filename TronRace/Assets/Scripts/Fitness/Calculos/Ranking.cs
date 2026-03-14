using System.Collections.Generic;
using UnityEngine;
using Entrance.Games.Mathematics;
using System.Linq;

namespace Entrance.Games.Mathematics
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
        [SerializeField] private MathBoardManager[] mathBoardManagers;
        [SerializeField] private RankingDisplayer rankingDisplayer;
        [SerializeField] private GeneralAnimator generalAnimator;

        [Header("Dictionary")]
        [SerializeField] private Dictionary<int, int> mathBoardsRank = new Dictionary<int, int>();
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            rankingDisplayer.Restart();
            mathBoardsRank.Clear();
            generalAnimator.Restart();
        }

        public void DisplayRanking()
        {
            for (int i = 0; i < mathBoardManagers.Length; i++)
            {
                mathBoardsRank.Add(i + 1, mathBoardManagers[i].scoreManager.currentPoints);
            }
            var orderedBoards = mathBoardsRank.OrderByDescending(pair => pair.Value).ToList();
            rankingDisplayer.DisplayIntValues(orderedBoards);
        }
        #endregion
    }
}