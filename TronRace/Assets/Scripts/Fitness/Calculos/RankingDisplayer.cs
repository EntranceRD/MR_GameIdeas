using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RankType
{
    SinglePlayer,
    Players,
    Teams,
}

namespace Entrance.Games.Mathematics
{
    public class RankingDisplayer : MonoBehaviour
    {
        #region UNITY METHODS
        #endregion

        #region VARIABLES
        [Header("References")]
        [SerializeField] private RankType type;
        [SerializeField] private List<TextMeshProUGUI> rankingTxt = new List<TextMeshProUGUI>();
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            for (int i = 0; i < rankingTxt.Count; i++)
            {
                rankingTxt[i].text = string.Empty;
            }
        }

        public void Display(List<KeyValuePair<int, int>> orderedPairs)
        {
            var text = TextBytype();
            for (int i = 0; i < rankingTxt.Count; i++)
            {
                var pair = orderedPairs[i];
                rankingTxt[i].text = $"{text} {pair.Key} - Puntos: {pair.Value}";
            }
        }

        private String TextBytype()
        {
            switch (type)
            {
                case RankType.SinglePlayer:
                    return "Gladiador";
                case RankType.Players:
                    return "Jugador";
                case RankType.Teams:
                    return "Equipo";
                default:
                    break;
            }
            return "";
        }
        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}