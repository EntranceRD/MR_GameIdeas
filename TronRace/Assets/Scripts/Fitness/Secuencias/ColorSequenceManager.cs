using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSequenceManager : MonoBehaviour
{
    public static ColorSequenceManager Instance { get; private set; }
    public ColorSequence colorSequence; 
    public ColorBoard[] boards;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
    }

    public void StartGame()
    {
        colorSequence.Restart();
        colorSequence.DisplaySequence(); 

        for (int i = 0; i < boards.Length; ++i)
        {
            boards[i].InitializeColor(colorSequence.colors);
            boards[i].OnNewSequenceCompare = colorSequence.CompareSequence;
        }
    }

    public void NewSequence()
    {
        colorSequence.NextSequence();
        StartGame();
    }
}