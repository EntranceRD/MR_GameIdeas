using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Entrance.Games.MarioKart 
{
    public class RankingDisplayer : MonoBehaviour
    {
        #region VARIABLES
        [Header("References")]
        public List<TextMeshProUGUI> rankingTxt = new List<TextMeshProUGUI>();
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            for (int i = 0; i < rankingTxt.Count; i++)
            {
                rankingTxt[i].text = string.Empty;
            }
        }

        public void Display(Dictionary<int, float> valuePairs)
        {
            int index = 0;
            foreach (var pair in valuePairs)
            {
                if (index < rankingTxt.Count)
                {
                    rankingTxt[index].text =
                        $"Jugador {pair.Key} - Tiempo: {pair.Value:F2}";
                }
                index++;
            }
        }
        #endregion
    }
}