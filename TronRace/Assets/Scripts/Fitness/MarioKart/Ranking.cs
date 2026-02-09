using Entrance;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    #region VARIABLES
    [Header("References")]
    [SerializeField] private RankingDisplayer rankingDisplayer;
    [SerializeField] private GenericStopwatchComponent stopwatch;

    [Header("Rank")]
    [SerializeField] private Dictionary<int,float> driversRank = new Dictionary<int,float>();
    #endregion

    #region PUBLIC METHODS
    public void Restart()
    {
        rankingDisplayer.Restart();
        driversRank.Clear();
        stopwatch.Restart();
        stopwatch.Resume();
    }

    public void AddPlayer(int driverID)
    {
        driversRank.Add(driverID, stopwatch.SetFlag());
    }

    public void DisplayRanking()
    {
        rankingDisplayer.Display(driversRank);
    }
    #endregion
}