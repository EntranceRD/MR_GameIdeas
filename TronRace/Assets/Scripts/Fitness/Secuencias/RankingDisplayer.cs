using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Entrance.Games.Sequence 
{
    public class RankingDisplayer : MonoBehaviour
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

        public void Display(List<KeyValuePair<int, int>> orderedPairs)
        {
            for (int i = 0; i < rankingTxt.Count; i++)
            {
                var pair = orderedPairs[i];
                rankingTxt[i].text = $"Equipo {pair.Key} - Points: {pair.Value}";
            }
            //int index = 0;
            //foreach (var pair in orderedPairs)
            //{
            //    if (index < rankingTxt.Count)
            //    {
            //        rankingTxt[index].text =
            //            $"Board {pair.Key+1} - Points: {pair.Value}";
            //    }
            //    index++;
            //}
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}