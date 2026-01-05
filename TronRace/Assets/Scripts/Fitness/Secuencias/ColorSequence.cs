using System.Collections.Generic;
using UnityEngine;

public enum ColorSequenceComparisonResult
{
    Incomplete,
    Incorrect,
    Correct
}

public class ColorSequence : MonoBehaviour
{
    #region VARIABLES
    public ColorData[] colors;
    public List<int> newColorSequence { get; private set; }
    private int sequenceSize;
    private SequenceGenerator generator;

    #endregion

    #region UNITY METHODS
    void Awake()
    {
        generator = new SequenceGenerator();
    }
    #endregion

    #region PUBLIC METHODS

    public void Restart()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].used = false;
        }
    }

    public List<int> CreateNewColorSequence(int players)
    {
        sequenceSize = players;
        PrepareNewSequence(sequenceSize);
        Debug.Log("New Sequence: " + string.Join(",", newColorSequence));
        return newColorSequence;
    }

    /*public ColorSequenceComparisonResult CompareSequence(List<int> otherSequence)
    {
        for (int i = 0; i < otherSequence.Count; i++)
        {
            if (otherSequence[i] != newColorSequence[i])
                return ColorSequenceComparisonResult.Incorrect;
        }

        if (otherSequence.Count < newColorSequence.Count)
            return ColorSequenceComparisonResult.Incomplete;

        return ColorSequenceComparisonResult.Correct;
    }*/

    public Color[] GetDisplayColors()
    {
        Color[] result = new Color[sequenceSize];

        for (int i = 0; i < sequenceSize; i++)
        {
            int colorIndex = newColorSequence[i];
            result[i] = colors[colorIndex].color;
        }

        return result;
    }

    #endregion

    #region PRIVATE METHODS
    private void PrepareNewSequence(int size)
    {
        List<int> availableColorsIndedexes = new List<int>();
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
        availableColorsIndedexes.Shuffle();

        if (newColorSequence == null) { newColorSequence = new List<int>(); }
        newColorSequence.Clear();
        for (int i = 0; i < size; i++)
        {
            var colorIndex = availableColorsIndedexes[i];

            newColorSequence.Add(colorIndex);
            colors[colorIndex].used = true;
        }
    }
    #endregion
}