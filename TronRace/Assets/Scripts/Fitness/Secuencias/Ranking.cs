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
        [Header("Settings")]
        [SerializeField] private RankType rankType;

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
            //var text = TextByType();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                boardsRank.Add(i + 1, colorBoards[i].scoreManager.currentPoints);
            }
            var orderedBoards = boardsRank.OrderByDescending(pair => pair.Value).ToList();
            //rankingDisplayer.DisplayIntValues(orderedBoards, text);
        }

        private string TextByType(List<KeyValuePair<int, int>> orderedPairs)
        {
            switch (rankType)
            {
                case RankType.SinglePlayer:
                    return "Gladiador";
                case RankType.Players:
                    return "Jugador";
                case RankType.Teams:
                    return string.Join(", ", orderedPairs.Select(pair => $"Equipo {pair.Key} - Puntos: {pair.Value}"));
                default:
                    break;
            }
            return "";
        }
        #endregion
    }
}