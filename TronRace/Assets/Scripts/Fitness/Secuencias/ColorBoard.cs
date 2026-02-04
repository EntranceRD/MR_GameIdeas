using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBoard : MonoBehaviour
{
    #region VARIABLES
    //public List<Image> userDisplayColors;
    //public List<Image> userImageButtons;
    public List<int> boardCurrentSequence;
    public SequenceButton[] sequenceButtons;

    public ScoreManager scoreManager;
    public bool finishCurrentSequence = true;

    [SerializeField] private int[] sequenceColorsValues;
    private List<int> userSequence = new List<int>();
    private Color fadedWhite = new Color(1f, 1f, 1f, 76f / 255f);

    public delegate ColorSequenceComparisonResult DelegateSample(List<int> colors);
    public DelegateSample OnNewSequenceCompare;


    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        DiseabledBoard();
    }
    #endregion

    #region PUBLIC METHODS

    public void Restart()
    {
        StopAllCoroutines();
        finishCurrentSequence = true;
        RestartUserSequence();
        CleanColorDisplay();
        DiseabledBoard();
    }

    public void RestartUserSequence() 
    { 
        userSequence.Clear();
        boardCurrentSequence.Clear();
    }

    public void InitializeBoard()
    //public void InitializeBoard(Color[] currentSequenceColors)
    {
        finishCurrentSequence = false;
        EneableBoard();
        //InitializeColors(currentSequenceColors);
        OnNewSequenceCompare = CompareWithBoardSequence;
    }

    public void AddColorToSequence(int buttonIndex)
    {
        //int currentColorValue = sequenceColorsValues[buttonIndex];
        //userSequence.Add(currentColorValue);
        userSequence.Add(buttonIndex);
        var result = OnNewSequenceCompare?.Invoke(userSequence);
        switch (result)
        {
            case ColorSequenceComparisonResult.Correct:

                sequenceButtons[buttonIndex].HighLight(1f);
                //userDisplayColors[userSequence.Count - 1].color = userImageButtons[buttonIndex].color;
                scoreManager.AddPoints(buttonIndex + 1);
                ColorSequenceManager.Instance.NewColorSequence(boardCurrentSequence.Count);
                Restart();
                break;

            case ColorSequenceComparisonResult.Incorrect:

                IncorrectSequence();
                break;

            case ColorSequenceComparisonResult.Incomplete:

                //userDisplayColors[userSequence.Count - 1].color = userImageButtons[buttonIndex].color;
                scoreManager.AddPoints(buttonIndex + 1);
                sequenceButtons[buttonIndex].HighLight(1f);
                break;
        }
    }
    #endregion

    #region PRIVATE METHODS

    private void InitializeColors(Color[] colors)
    {
        //sequenceColorsValues = new int[userImageButtons.Count];
        List<Color> shuffledColors = new List<Color>(colors);
        List<int> shuffledValue = new List<int>(boardCurrentSequence);

        for (int i = 0; i < shuffledColors.Count; i++)
        {
            int randomIndex = Random.Range(i, shuffledColors.Count);

            (shuffledColors[i], shuffledColors[randomIndex]) = (shuffledColors[randomIndex], shuffledColors[i]);
            (shuffledValue[i], shuffledValue[randomIndex]) = (shuffledValue[randomIndex], shuffledValue[i]);
        }

        //for (int i = 0; i < boardCurrentSequence.Count; ++i)
        //{
        //    userImageButtons[i].color = shuffledColors[i];
        //    sequenceColorsValues[i] = shuffledValue[i];
        //}
    }

    private void InitializeButtonsColor(Color[] colors) 
    {
        
    }


    private void CleanColorDisplay()
    {
        //for (int i = 0; i < userDisplayColors.Count; ++i)
        //{
        //    userDisplayColors[i].color = fadedWhite;
        //}
    }

    private void IncorrectSequence()
    {
        SetButtonsInteraction(false);

        for (int i = 0; i < sequenceButtons.Length; i++)
        {
            sequenceButtons[i].Blink(0.5f, 2);
        }
        userSequence.Clear();
        SetButtonsInteraction(true);
        ColorSequenceManager.Instance.ReDisplaySequence();
    }

    private void DiseabledBoard()
    {
        SetButtonsInteraction(false);

        //foreach (var image in userImageButtons)
        //{
        //    image.color = fadedWhite;
        //    image.enabled = false;
        //}
        //foreach (var display in userDisplayColors)
        //{
        //    display.enabled = false;
        //}
    }


    private void EneableBoard()
    {
        //for (int i = 0; i < boardCurrentSequence.Count; ++i)
        //{
        //    userImageButtons[i].enabled = true;
        //    userDisplayColors[i].enabled = true;
        //}
        SetButtonsInteraction(true);
    }

    private void SetButtonsInteraction(bool state)
    {
        for (int i = 0; i < sequenceButtons.Length; i++)
        {
            sequenceButtons[i].SetInteraction(state);
        }
    }



    private ColorSequenceComparisonResult CompareWithBoardSequence(List<int> otherSequence)
    {
        for (int i = 0; i < otherSequence.Count; i++)
        {
            if (otherSequence[i] != boardCurrentSequence[i])
                return ColorSequenceComparisonResult.Incorrect;
        }

        if (otherSequence.Count < boardCurrentSequence.Count)
            return ColorSequenceComparisonResult.Incomplete;

        return ColorSequenceComparisonResult.Correct;
    }
    #endregion
}