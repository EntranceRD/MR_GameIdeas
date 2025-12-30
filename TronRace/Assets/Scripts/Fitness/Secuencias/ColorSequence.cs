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
    #region VARIABLES
    private SequenceGenerator generator;
    public ColorData[] colors;

    public List<int> currentSequence { get; private set; }
    private bool displayingSequence = false;

    [SerializeField, Range(2,10)] private int sequenceSizeRange;
    private int currentSequenceSize;
    [SerializeField] private Image[] sequenceDisplay;

    private float initialWaitTime = 1.0f;
    private float colorDisplayTime = 1.0f;
    private float awaitBetweenColors = 0.5f;
    #endregion

    #region UNITY METHODS
    void Awake()
    {
        generator = new SequenceGenerator();
    }
    #endregion

    #region PUBLIC METHODS
    public void Restart(int players)
    {
        currentSequenceSize = players;
        PrepareNewSequence(currentSequenceSize);
        Debug.Log("New Sequence: " + string.Join(",", currentSequence));
    }

    public void NextSequence()
    {
        sequenceSizeRange++;
        currentSequenceSize = sequenceSizeRange;
        PrepareNewSequence(currentSequenceSize);
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

    public Coroutine DisplaySequence()
    {
        if (displayingSequence) return null;
        displayingSequence = true;
        return StartCoroutine(DisplayCurrentSequence());
    }

    public Color[] GetDisplayColors()
    {
        Color[] result = new Color[currentSequenceSize];

        for (int i = 0; i < currentSequenceSize; i++)
        {
            int colorIndex = currentSequence[i];
            result[i] = colors[colorIndex].color;
        }

        return result;
    }

    #endregion

    #region PRIVATE METHODS

    private IEnumerator DisplayCurrentSequence()
    {
        yield return new WaitForSeconds(initialWaitTime);
        Color[] displayColors = GetDisplayColors();

        for (int i = 0; i < currentSequence.Count; ++i)
        {
            int wallIndex = i % sequenceDisplay.Length;
            sequenceDisplay[wallIndex].color = displayColors[i];
            yield return new WaitForSeconds(colorDisplayTime);

            sequenceDisplay[wallIndex].color = Color.black;
            yield return new WaitForSeconds(awaitBetweenColors);
        }

        displayingSequence = false;
    }

    public void PrepareNewSequence(int size)
    {
        List<int>availableColorsIndedexes = new List<int>();
        for (int i = 0; i < colors.Length; ++i)
        {
            if (!colors[i].used)
            {
                availableColorsIndedexes.Add(i);
            }
            else
            {
                colors[i].used = false;
            }
        }

        currentSequence = generator.CreateSequence(4, availableColorsIndedexes.Count, size);

        for (int i = 0; i < currentSequence.Count; ++i)
        {
            var colorIndex = currentSequence[i];
            colors[colorIndex].used = true;
        }
    }
    #endregion
}