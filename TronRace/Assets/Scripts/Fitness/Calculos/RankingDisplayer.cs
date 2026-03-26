//using Entrance.UI;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public enum RankType
//{
//    SinglePlayer,
//    Players,
//    Teams
//}

//namespace Entrance.Games
//{
//    public class RankingDisplayer : MonoBehaviour
//    {
//        #region UNITY METHODS
//        #endregion

//        #region VARIABLES
//        [Header("References")]
//        [SerializeField] private RankType type;
//        [SerializeField] private List<Display_Text> rankingTxt = new List<Display_Text>();

//        [SerializeField] private ButtonEvent eventsAfterDisplay;
//        [SerializeField] private ButtonEvent eventsOnStartDisplay;
//        private bool displayingInstructions = false;
//        #endregion

//        #region PUBLIC METHODS
//        public void Restart()
//        {
//            for (int i = 0; i < rankingTxt.Count; i++)
//            {
//                rankingTxt[i].SetData(string.Empty);
//                //rankingTxt[i].text = string.Empty;
//            }
//        }



//        public void DisplayIntValues(List<KeyValuePair<int, int>> orderedPairs)
//        {
//            var text = TextByType();

//            for (int i = 0; i < rankingTxt.Count && i < orderedPairs.Count; i++)
//            {
//                var pair = orderedPairs[i];
//                rankingTxt[i].SetData($"{text} {pair.Key} - Puntos: {pair.Value}");
//                //rankingTxt[i].text = $"{text} {pair.Key} - Puntos: {pair.Value}";
//            }
//        }

//        public void DisplayFloatValues(List<KeyValuePair<int, float>> orderedPairs)
//        {
//            var text = TextByType();
//            for (int i = 0; i < rankingTxt.Count; i++)
//            {
//                var pair = orderedPairs[i];
//                rankingTxt[i].SetData($"{text} {pair.Key} - Tiempo: {pair.Value}");
//                //rankingTxt[i].text = $"{text} {pair.Key} - Tiempo: {pair.Value}";
//            }
//        }

//        public void DisplayBlueVsRedValues(List<KeyValuePair<TeamColor, int>> orderedPairs)
//        {
//            var text = TextByType();
//            for (int i = 0; i < rankingTxt.Count; i++)
//            {
//                var pair = orderedPairs[i];
//                rankingTxt[i].SetData($"Equipo {pair.Key} - Puntos: {pair.Value}");
//                //rankingTxt[i].text = $"Equipo {pair.Key} - Puntos: {pair.Value}";
//            }
//        }
//        #endregion

//        #region PRIVATE METHODS
//        private string TextByType()
//        {
//            switch (type)
//            {
//                case RankType.SinglePlayer:
//                    return "Gladiador";
//                case RankType.Players:
//                    return "Jugador";
//                case RankType.Teams:
//                    return "Equipo";
//                default:
//                    break;
//            }
//            return "";
//        }
//        #endregion
//    }
//}

using Entrance.UI;
using System;
using System.Collections;
using System.Collections.Generic;
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
        #region VARIABLES
        [Header("References")]
        [SerializeField] private RankType type;
        [SerializeField] private List<Display_Text> rankingTxt = new();

        [Header("Settings")]
        [SerializeField] private float displayTime = 3f;
        [SerializeField] private bool oneByOne = true;

        [Header("Events")]
        [SerializeField] private ButtonEvent eventsOnStartDisplay;
        [SerializeField] private ButtonEvent eventsDuringDisplay;
        [SerializeField] private ButtonEvent eventsAfterDisplay;

        private bool displaying = false;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            StopAllCoroutines();
            displaying = false;

            foreach (var txt in rankingTxt)
            {
                txt.SetData(string.Empty);
                txt.Restart();
            }
        }

        public void Display<T>(List<KeyValuePair<T, float>> floatData = null, List<KeyValuePair<T, int>> intData = null)
        {
            if (displaying) return;

            displaying = true;
            eventsOnStartDisplay.Call();

            StartCoroutine(ShowRanking(floatData, intData));
        }

        public void DisplayBlueVsRedValues(List<KeyValuePair<TeamColor, int>> orderedPairs)
        {
            var text = TextByType();
            for (int i = 0; i < rankingTxt.Count; i++)
            {
                var pair = orderedPairs[i];
                rankingTxt[i].SetData($"Equipo {pair.Key} - Puntos: {pair.Value}");
                //rankingTxt[i].text = $"Equipo {pair.Key} - Puntos: {pair.Value}";
            }
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator ShowRanking<T>(List<KeyValuePair<T, float>> floatData, List<KeyValuePair<T, int>> intData)
        {
            float eachTime = oneByOne ? displayTime / rankingTxt.Count : displayTime;

            for (int i = rankingTxt.Count - 1; i >= 0; i--)
            {
                string text = GetFormattedText(i, floatData, intData);

                if (string.IsNullOrEmpty(text)) continue;

                rankingTxt[i].SetData(text);
                rankingTxt[i].Show();

                if (oneByOne)
                    yield return new WaitForSeconds(eachTime);
            }
            //for (int i = 0; i < rankingTxt.Count; i++)
            //{
            //    string text = GetFormattedText(i, floatData, intData);

            //    if (string.IsNullOrEmpty(text)) continue;

            //    rankingTxt[i].SetData(text);
            //    rankingTxt[i].Show();

            //    if (oneByOne)
            //    {
            //        yield return new WaitForSeconds(eachTime);
            //        //rankingTxt[i].Hide();
            //    }
            //}

            if (!oneByOne)
                yield return new WaitForSeconds(displayTime);

            //eventsDuringDisplay.Call();

            //foreach (var txt in rankingTxt)
            //    txt.Hide();

            displaying = false;
            eventsAfterDisplay.Call();
        }

        private string GetFormattedText<T>(int index, List<KeyValuePair<T, float>> floatData, List<KeyValuePair<T, int>> intData)
        {
            string prefix = TextByType();

            switch (type)
            {
                case RankType.Teams:
                    if (intData != null && index < intData.Count)
                    {
                        var pair = intData[index];
                        return $"Equipo {pair.Key} - Puntos: {pair.Value}";
                    }
                    break;

                case RankType.SinglePlayer:
                case RankType.Players:

                    if (floatData != null && index < floatData.Count)
                    {
                        var pair = floatData[index];
                        return $"{prefix} {pair.Key} - Tiempo: {pair.Value}";
                    }

                    if (intData != null && index < intData.Count)
                    {
                        var pair = intData[index];
                        return $"{prefix} {pair.Key} - Puntos: {pair.Value}";
                    }
                    break;
            }

            return string.Empty;
        }

        private string TextByType()
        {
            return type switch
            {
                RankType.SinglePlayer => "Gladiador",
                RankType.Players => "Jugador",
                RankType.Teams => "Equipo",
                _ => ""
            };
        }
        #endregion
    }
}