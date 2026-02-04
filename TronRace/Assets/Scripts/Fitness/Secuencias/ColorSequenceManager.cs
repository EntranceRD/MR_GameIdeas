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
    private int initialSequenceSize;
    private int sequenceSize;
    [SerializeField] private float initialWaitTime = 1.0f;
    [SerializeField] private float colorDisplayTime = 1.0f;
    [SerializeField] private float awaitBetweenColors = 0.5f;
    [SerializeField] private SequenceButton[] sequenceButtons;
    private bool displayingSequence = false;
    private List<int> currentSequence = new List<int>();

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
    public void ReDisplaySequence() { StartCoroutine(displaySequence()); }
    public void Restart(int players)
    {
        StopAllCoroutines();
        displayingSequence = false;
        sequenceSize = players;
        initialSequenceSize = players;
        for (int i = 0; i < sequenceButtons.Length; i++)
        {
            sequenceButtons[i].InitializeColor(colorSequence.colors[i].color);
        }
        //StartCoroutine(StartColorSequence(sequenceSize));
    }

    public IEnumerator StartColorSequence(int players)
    {
        sequenceSize = players;
        //var newSequence = colorSequence.CreateNewColorSequence(sequenceSize);
        currentSequence = colorSequence.CreateNewColorSequence(sequenceSize);

        yield return new WaitForSeconds(2f);
        yield return DisplaySequence(currentSequence);

        for (int i = 0; i < boards.Length; ++i)
        {
            if (boards[i].finishCurrentSequence == false) continue;

            boards[i].boardCurrentSequence = new List<int>(currentSequence);
            boards[i].InitializeBoard();
        }
    }
    private IEnumerator displaySequence() {
        yield return new WaitForSeconds(3f);
        yield return DisplaySequence(currentSequence);

        for (int i = 0; i < boards.Length; ++i)
        {
            if (boards[i].finishCurrentSequence == false) continue;

            boards[i].boardCurrentSequence = new List<int>(currentSequence);
            boards[i].InitializeBoard();
        }
    }

    public void NewColorSequence(int boardSequenceSize)
    {
        boardSequenceSize = Mathf.Min(boardSequenceSize + 1, 6);
        //if (boardSequenceSize > (colorSequence.colors.lenght / 2)) {
        //    colorSequence.colors.restarts();
        //}
        //boardSequenceSize = Mathf.Min(boardSequenceSize + 1, initialSequenceSize * 3);
        StartCoroutine(StartColorSequence(boardSequenceSize));
    }

    public Coroutine DisplaySequence(List<int>sequence)
    {
        if (displayingSequence) return null;
        displayingSequence = true;
        return StartCoroutine(DisplayCurrentSequence(sequence));
    }

    #endregion

    #region PRIVATE METHODS   

    private IEnumerator DisplayCurrentSequence(List<int> sequence)
    {
        SetButtonsInteraction(false);
        yield return new WaitForSeconds(initialWaitTime);

        for (int i = 0; i < sequence.Count; ++i)
        {
            sequenceButtons[sequence[i]].HighLight(colorDisplayTime);
            yield return new WaitForSeconds(colorDisplayTime + awaitBetweenColors);
        }

        displayingSequence = false;
        SetButtonsInteraction(true);
    }

    private void SetButtonsInteraction(bool state)
    {
        for (int i = 0; i < sequenceButtons.Length; i++)
        {
            sequenceButtons[i].SetInteraction(state);
        }
    }
    #endregion
}