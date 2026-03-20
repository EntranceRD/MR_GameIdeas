using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum RankType
{
    SinglePlayer,
    Players,
    Teams
}

namespace Entrance.Games
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

        public void DisplayIntValues(List<KeyValuePair<int, int>> orderedPairs)
        {
            var text = TextByType();

            for (int i = 0; i < rankingTxt.Count && i < orderedPairs.Count; i++)
            {
                var pair = orderedPairs[i];
                rankingTxt[i].text = $"{text} {pair.Key} - Puntos: {pair.Value}";
            }
        }

        public void DisplayFloatValues(List<KeyValuePair<int, float>> orderedPairs)
        {
            var text = TextByType();
            for (int i = 0; i < rankingTxt.Count; i++)
            {
                var pair = orderedPairs[i];
                rankingTxt[i].text = $"{text} {pair.Key} - Tiempo: {pair.Value}";
            }
        }

        public void DisplayBlueVsRedValues(List<KeyValuePair<TeamColor, int>> orderedPairs)
        {
            var text = TextByType();
            for (int i = 0; i < rankingTxt.Count; i++)
            {
                var pair = orderedPairs[i];
                rankingTxt[i].text = $"Equipo {pair.Key} - Puntos: {pair.Value}";
            }
        }
        #endregion

        #region PRIVATE METHODS
        private string TextByType()
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
    }
}