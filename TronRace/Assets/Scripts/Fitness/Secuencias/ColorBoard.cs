using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBoard : MonoBehaviour
{
    #region VARIABLES
    public List<Image> userDisplayColors;
    public List<Image> userImageButtons;
    public List<Collider> buttonsInteractions;
    public List<int> boardCurrentSequence;

    private int[] sequenceColorsValues;
    private List<int> userSequence = new List<int>();

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
        RestartUserSequence();
        CleanColorDisplay();
        DiseabledBoard();
    }

    public void RestartUserSequence() 
    { 
        userSequence.Clear();
    }

    public void InitializeBoard(Color[] currentSequenceColors)
    {
        InitializeButtonsImage();
        EneabledUserButtons();
        InitializeDisplays();
        InitializeColors(currentSequenceColors);
    }
    public void AddColorToSequence(int buttonIndex)
    {
        int currentColorValue = sequenceColorsValues[buttonIndex];
        userSequence.Add(currentColorValue);
        var result = OnNewSequenceCompare?.Invoke(userSequence);
        switch (result)
        {
            case ColorSequenceComparisonResult.Correct:

                userDisplayColors[userSequence.Count - 1].color = userImageButtons[buttonIndex].color;
                ScoreManager.Instance.AddPoints(buttonIndex + 1);
                CleanColorDisplay();
                DiseabledBoard();
                RestartUserSequence();
                ColorSequenceManager.Instance.NewColorSequence();
                break;

            case ColorSequenceComparisonResult.Incorrect:

                StartCoroutine(IncorrectSequence());
                break;

            case ColorSequenceComparisonResult.Incomplete:

                userDisplayColors[userSequence.Count - 1].color = userImageButtons[buttonIndex].color;
                ScoreManager.Instance.AddPoints(buttonIndex + 1);
                break;
        }
    }
    #endregion

    #region PRIVATE METHODS

    private void InitializeButtonsImage()
    {
        for (int i = 0; i < boardCurrentSequence.Count; ++i)
        {
            userImageButtons[i].enabled = true;
        }
    }

    private void InitializeDisplays()
    {
        for (int i = 0; i < boardCurrentSequence.Count; ++i)
        {
            userDisplayColors[i].enabled = true;
        }
    }

    private void InitializeColors(Color[] colors)
    {
        sequenceColorsValues = new int[userImageButtons.Count];
        List<Color> shuffledColors = new List<Color>(colors);
        List<int> shuffledValue = new List<int>(boardCurrentSequence);

        for (int i = 0; i < shuffledColors.Count; i++)
        {
            int randomIndex = Random.Range(i, shuffledColors.Count);

            (shuffledColors[i], shuffledColors[randomIndex]) = (shuffledColors[randomIndex], shuffledColors[i]);
            (shuffledValue[i], shuffledValue[randomIndex]) = (shuffledValue[randomIndex], shuffledValue[i]);
        }

        for (int i = 0; i < boardCurrentSequence.Count; ++i)
        {
            userImageButtons[i].color = shuffledColors[i];
            sequenceColorsValues[i] = shuffledValue[i];
        }
    }

    private void CleanColorDisplay()
    {
        Color fadedWhite = new Color(1f, 1f, 1f, 76f / 255f);
        for (int i = 0; i < userDisplayColors.Count; ++i)
        {
            userDisplayColors[i].color = fadedWhite;
        }
    }

    private IEnumerator IncorrectSequence()
    {
        
        DiseabledUserButtons();

        for (int i = 0; i < 2; ++i)
        {
            foreach (var img in userDisplayColors)
            {
                img.color = Color.red;
            }
            yield return new WaitForSeconds(0.5f);
            CleanColorDisplay();
            yield return new WaitForSeconds(0.5f);
        }
        
        RestartUserSequence();
        EneabledUserButtons();
    }

    private void DiseabledBoard()
    {
        foreach (var button in buttonsInteractions)
        {
            button.enabled = false;
        }
        foreach (var image in userImageButtons)
        {
            image.enabled = false;
        }
        foreach (var display in userDisplayColors)
        {
            display.enabled = false;
        }

    }

    private void EneabledUserButtons()
    {
        for (int i = 0; i < boardCurrentSequence.Count; ++i)
        {
            buttonsInteractions[i].enabled = true;
        }
    }

    private void DiseabledUserButtons()
    {
        for (int i = 0; i < boardCurrentSequence.Count; ++i)
        {
            buttonsInteractions[i].enabled = false;
        }
    }

#endregion
}