using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardDisplayer : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private SequenceDisplayer displayer;
    [SerializeField] private float initialWaitTime = 1.0f;
    [SerializeField] private SequenceButton[] sequenceButtons;
    public List<GameObject> panels = new List<GameObject>();

    #endregion

    #region UNITY METHODS
    private void Awake()
    {

    }
    #endregion

    #region PUBLIC METHODS
    public void ReDisplaySequence(List<int> sequence) 
    {
        StartSequence(sequence);
    }

    public void Restart()
    {
        InitializeButtonsColors();  
        StopAllCoroutines();
        displayer.Initialize();
        displayer.OnDisplayElement -= DisplaySequenceIndex;
        displayer.OnDisplayElement += DisplaySequenceIndex;

        displayer.OnFinishDisplaying -= EnableAllButtons;
        displayer.OnFinishDisplaying += EnableAllButtons;
    }

    public void StartSequence(List<int> sequence)
    {
        StartCoroutine(DisplaySequence(sequence));
    }

    private void InitializeButtonsColors()
    {
        for (int i = 0; i < sequenceButtons.Length; i++)
        {
            sequenceButtons[i].InitializeColor(ColorSequence.Instance.colors[i].color);
        }
    }

    #endregion

    #region PRIVATE METHODS   
    private IEnumerator DisplaySequence(List<int> sequence)
    {
        ActiveWaitPanel(true);
        yield return new WaitForSeconds(3f);
        yield return displayCurrentSequence(sequence);
        ActiveWaitPanel(false);
    }

    private IEnumerator displayCurrentSequence(List<int> sequence)
    {
        SetButtonsInteraction(false);
        yield return new WaitForSeconds(initialWaitTime);

        displayer.DisplaySequence(sequence);
    }

    private void DisableAllButtons() { SetButtonsInteraction(false); }
    private void EnableAllButtons() { SetButtonsInteraction(true); }
    private void SetButtonsInteraction(bool state)
    {
        for (int i = 0; i < sequenceButtons.Length; i++)
        {
            sequenceButtons[i].SetInteraction(state);
        }
    }
    private void ActiveWaitPanel(bool state)
    {
        for (int i = 0; i < panels.Count; ++i)
        {
            panels[i].SetActive(state);
        }
    }
    private void DisplaySequenceIndex(int buttonIndex, int index)
    {
        sequenceButtons[buttonIndex].InitializeIndex(index);
    }
    #endregion
}