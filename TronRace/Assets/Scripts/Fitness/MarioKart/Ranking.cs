using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    #region UNITY METHODS

    #endregion

    #region VARIABLES

    [SerializeField] private List<(int driverID, float time)> rankingScores = new List<(int, float)>();
    public TextMeshProUGUI rankingTxt;


    #endregion

    #region PUBLIC METHODS
    public void AddPlayer(int driverID, float time)
    {
        rankingScores.Add((driverID, time));
    }

    public void SortByTime()
    {
        rankingScores.Sort((a, b) => a.time.CompareTo(b.time));
    }

    public void DisplayRanking()
    {
        //rankingTxt.text = "";
        Debug.Log("---Final Ranking---");
        for (int i = 0; i < rankingScores.Count; i++)
        {
            Debug.Log($"Position {i + 1}: Driver {rankingScores[i].driverID} - Time: {rankingScores[i].time:F2} seconds");
            //rankingTxt.text = rankingTxt.text + $"Position {i + 1}: Driver {rankingScores[i].driverID} - Time: {rankingScores[i].score:F2} seconds\n\n";
        }
    }

    public void ClearRanking()
    {
        rankingScores.Clear();
        //rankingTxt.text = "";
    }

    #endregion

    #region PRIVATE METHODS

    #endregion
}