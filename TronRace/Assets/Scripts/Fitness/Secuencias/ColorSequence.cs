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

    //[SerializeField, Range(2,10)] private int sequenceSizeRange;
    private int currentSequenceSize;
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

    public void CreateNewColorSequence(int players)
    {
        currentSequenceSize = players;
        PrepareNewSequence(currentSequenceSize);
        Debug.Log("New Sequence: " + string.Join(",", newColorSequence));
    }

    public void PrepareNewSequence(int size)
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
            colors[colorIndex].used= true;
        }
    }

    public ColorSequenceComparisonResult CompareSequence(List<int> otherSequence)
    {
        for (int i = 0; i < otherSequence.Count; i++)
        {
            if (otherSequence[i] != newColorSequence[i])
                return ColorSequenceComparisonResult.Incorrect;
        }

        if (otherSequence.Count < newColorSequence.Count)
            return ColorSequenceComparisonResult.Incomplete;

        return ColorSequenceComparisonResult.Correct;
    }

    public Color[] GetDisplayColors()
    {
        Color[] result = new Color[currentSequenceSize];

        for (int i = 0; i < currentSequenceSize; i++)
        {
            int colorIndex = newColorSequence[i];
            result[i] = colors[colorIndex].color;
        }

        return result;
    }

    #endregion

    #region PRIVATE METHODS
    
    #endregion
}