using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceDisplayer : MonoBehaviour
{

    #region VARIABLES
    public System.Action OnStartDisplaying;
    public System.Action OnFinishDisplaying;
    public System.Action<int, int> OnDisplayElement;
    public bool displayingSequence { get; private set; } = false;

    [SerializeField, Range(0, 5f)] private float displayTime;
    [SerializeField, Range(0, 5f)] private float timeBetweenDisplay;

    private IEnumerator displaySequenceInstruction;
    private IHighlightableObject[] highlightableObjects;
    private List<int> mySequence = new List<int>();
    [SerializeField] private Transform highlightableContainer;
    #endregion


    #region PUBLIC METHODS
    public void Initialize()
    {
        highlightableObjects = highlightableContainer.GetComponentsInChildren<IHighlightableObject>();

        if (displaySequenceInstruction == null)
        {
            displaySequenceInstruction = displaySequence();
        }
        ForceStop();
    }

    public void DisplaySequence(List<int> sequence)
    {
        if (displayingSequence) { return; }
        mySequence = sequence;
        if (displaySequenceInstruction == null)
        {
            displaySequenceInstruction = displaySequence();
        }

        displaySequenceInstruction = displaySequence();

        StartCoroutine(displaySequenceInstruction);
    }

    public void ForceStop()
    {
        displayingSequence = false;
        StopCoroutine(displaySequenceInstruction);
    }

    #endregion

    #region PRIVATE METHODS
    private IEnumerator displaySequence()
    {
        displayingSequence = true;
        OnStartDisplaying?.Invoke();

        var totalDisplayTime = displayTime + timeBetweenDisplay;
        for (int i = 0; i < mySequence.Count; i++)
        {
            OnDisplayElement?.Invoke(mySequence[i], i);
            highlightableObjects[mySequence[i]].Highlight(displayTime);
            yield return new WaitForSeconds(totalDisplayTime);
        }
        displayingSequence = false;
        OnFinishDisplaying?.Invoke();
    }
    #endregion
}