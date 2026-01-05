using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSequenceManager : MonoBehaviour
{
    #region VARIABLES
    public static ColorSequenceManager Instance { get; private set; }
    public ColorSequence colorSequence; 
    public ColorBoard[] boards;
    private int sequenceSize;
    private float initialWaitTime = 1.0f;
    private float colorDisplayTime = 1.0f;
    private float awaitBetweenColors = 0.5f;
    private bool displayingSequence = false;
    [SerializeField] private Image[] sequenceDisplay;
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
    public void Restart(int players)
    {
        StopAllCoroutines();
        displayingSequence = false;
        sequenceSize = players;
        for (int i = 0; i < sequenceDisplay.Length; i++)
        {
            sequenceDisplay[i].color = Color.black;
        }
        StartCoroutine(StartColorSequence(sequenceSize));
    }

    public IEnumerator StartColorSequence(int players)
    {
        sequenceSize = players;
        var newSequence = colorSequence.CreateNewColorSequence(sequenceSize);
        Color[] displayColors = colorSequence.GetDisplayColors();

        yield return DisplaySequence();

        for (int i = 0; i < boards.Length; ++i)
        {
            if (boards[i].finishCurrentSequence == false) continue;

            boards[i].boardCurrentSequence = new List<int>(newSequence);
            boards[i].InitializeBoard(displayColors);
        }
    }

    public void NewColorSequence(int boardSequenceSize)
    {
        boardSequenceSize++;
        StartCoroutine(StartColorSequence(boardSequenceSize));
    }

    public Coroutine DisplaySequence()
    {
        if (displayingSequence) return null;
        displayingSequence = true;
        return StartCoroutine(DisplayCurrentSequence());
    }

    #endregion

    #region PRIVATE METHODS   

    private IEnumerator DisplayCurrentSequence()
    {
        yield return new WaitForSeconds(initialWaitTime);
        Color[] displayColors = colorSequence.GetDisplayColors();

        for (int i = 0; i < colorSequence.newColorSequence.Count; ++i)
        {
            int wallIndex = i % sequenceDisplay.Length;
            sequenceDisplay[wallIndex].color = displayColors[i];
            yield return new WaitForSeconds(colorDisplayTime);

            sequenceDisplay[wallIndex].color = Color.black;
            yield return new WaitForSeconds(awaitBetweenColors);
        }

        displayingSequence = false;
    }
    #endregion
}