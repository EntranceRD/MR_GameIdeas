using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ColorSequenceComparisonResult
{
    Incomplete,
    Incorrect,
    Correct
}
public class ColorSequence : MonoBehaviour
{
    private SequenceGenerator generator;
    public Color[] colors;
    public List<int> currentSequence { get; private set; }
    private bool displayingSequence = false;

    [SerializeField] private int sequenceSize = 4;
    [SerializeField] private Image[] sequenceDisplay;
    private float initialWaitTime = 1.0f;
    private float colorDisplayTime = 1.0f;
    private float awaitBetweenColors = 0.5f;

    void Awake()
    {
        generator = new SequenceGenerator();
    }

    public void Restart()
    {
        currentSequence = generator.CreateSequence(0, colors.Length, sequenceSize);
        Debug.Log("New Sequence: " + string.Join(",", currentSequence));
    }

    public void NextSequence()
    {
        sequenceSize++;
        currentSequence = generator.CreateSequence(0, colors.Length, sequenceSize);
    }

    public ColorSequenceComparisonResult CompareSequence(List<int> otherSequence)
    {
        for (int i = 0; i < otherSequence.Count; i++)
        {
            if (otherSequence[i] != currentSequence[i])
                return ColorSequenceComparisonResult.Incorrect;
        }

        if (otherSequence.Count < currentSequence.Count)
            return ColorSequenceComparisonResult.Incomplete;

        return ColorSequenceComparisonResult.Correct;
    }


    /*public bool[] GetColorsCorrectFromComparison(int[] otherSequence)
    {
        List<bool> results = new List<bool>();
        for (int i = 0; i < otherSequence.Length; ++i)
        {
            results.Add(currentSequence[i] != otherSequence[i]);
        }
        return results.ToArray();
    }*/

    public void DisplaySequence()
    {
        if (displayingSequence) { return; }
        displayingSequence = true;
        StartCoroutine(DisplayCurrentSequence());
    }

    private IEnumerator DisplayCurrentSequence()
    {
        yield return new WaitForSeconds(initialWaitTime);

        for (int i = 0; i < currentSequence.Count; ++i)
        {
            int colorIndex = currentSequence[i];
            sequenceDisplay[colorIndex].color = colors[colorIndex];
            yield return new WaitForSeconds(colorDisplayTime);

            sequenceDisplay[colorIndex].color = Color.black;
            yield return new WaitForSeconds(awaitBetweenColors);
        }

        displayingSequence = false;
    }
}