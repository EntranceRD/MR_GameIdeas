using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSequenceManager : MonoBehaviour
{
    #region VARIABLES
    public static ColorSequenceManager Instance { get; private set; }
    public ColorSequence colorSequence; 
    public ColorBoard[] boards;
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
    }
    #endregion

    #region PUBLIC METHODS
    public IEnumerator StartGame()
    {
        colorSequence.Restart();
        yield return colorSequence.DisplaySequence();
        Color[] displayColors = colorSequence.GetDisplayColors();

        for (int i = 0; i < boards.Length; ++i)
        {
            boards[i].currentSequence = colorSequence.currentSequence;
            boards[i].OnNewSequenceCompare = colorSequence.CompareSequence;
            boards[i].InitializeBoard(displayColors);
        }
    }

    public void NewSequence()
    {
        colorSequence.NextSequence();
        StartCoroutine(StartGame());
    }
    #endregion

    #region PRIVATE METHODS

    #endregion
}