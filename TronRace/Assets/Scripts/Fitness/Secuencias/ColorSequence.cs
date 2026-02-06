using System.Collections.Generic;
using UnityEngine;

public class ColorSequence : MonoBehaviour
{
    #region UNITY METHODS
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
        generator = new SequenceGenerator(AddNewNumberToSequenceCondition);
    }
    #endregion

    #region VARIABLES
    public static ColorSequence Instance;
    public ColorData[] colors;
    private int sequenceSize;
    private SequenceGenerator generator;
    #endregion

    #region PUBLIC METHODS
    public void Restart()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].used = false;
        }
        generator.ClearSequence();
    }

    public List<int> CreateNewColorSequence(int players)
    {
        sequenceSize = players;
        generator.CreateSequence(0,10, players);
        Debug.Log("New Sequence: " + string.Join(",", generator.mySequence));
        return generator.mySequence;
    }

    public List<int> GrowSequenceBy(int amount)
    {
        sequenceSize = generator.mySequence.Count + amount;
        generator.CreateSequence(0,10, sequenceSize);
        Debug.Log("Grow Sequence: " + string.Join(",", generator.mySequence));
        return generator.mySequence;
    }

    public Color[] GetDisplayColors()
    {
        Color[] result = new Color[sequenceSize];

        for (int i = 0; i < sequenceSize; i++)
        {
            int colorIndex = generator.mySequence[i];
            result[i] = colors[colorIndex].color;
        }
        return result;
    }
    #endregion

    #region PRIVATE METHODS

    private bool AddNewNumberToSequenceCondition(int newNumber)
    {
        return !generator.mySequence.Contains(newNumber);
    }
    #endregion
}