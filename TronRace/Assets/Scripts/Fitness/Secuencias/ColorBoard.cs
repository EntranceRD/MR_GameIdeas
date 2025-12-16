using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorBoard : MonoBehaviour
{
    public Image[] userColors;
    public Collider[] buttonsInteractions;
    public List<Image> userSelectedColors;
    private List<int> userSequence = new List<int>();
    public Image displayImagePrefab;
    public Transform displayParent; 

    public delegate ColorSequenceComparisonResult DelegateSample(List<int> colors);
    public DelegateSample OnNewSequenceCompare;
    public void Restart() { userSequence.Clear(); }
    public void InitializeColor(Color[] colors)
    {
        for (int i = 0; i < userColors.Length; ++i)
        {
            userColors[i].color = colors[i];
        }
    }

    public void AddColorToSequence(int index)
    {
        userSequence.Add(index);
        Debug.Log("User added color index: " + index);
        var result = OnNewSequenceCompare?.Invoke(userSequence);
        switch (result)
        {
            case ColorSequenceComparisonResult.Correct:
                userSelectedColors[userSequence.Count - 1].color = userColors[index].color;
                ScoreManager.Instance.AddPoints(index + 1);
                CleanColorDisplay();
                userSequence.Clear();
                Image newSlot = Instantiate(displayImagePrefab, displayParent);
                userSelectedColors.Add(newSlot);
                ColorSequenceManager.Instance.NewSequence();
                
                break;
            case ColorSequenceComparisonResult.Incorrect:
                //marcar errores en la secuencia
                //Hacer un singleton o static variables y method
                // var resultsFromSequence = GetColorsCorrectFromComparison(userSequence);
                StartCoroutine(IncorrectSequence());
                break;
            case ColorSequenceComparisonResult.Incomplete:
                userSelectedColors[userSequence.Count - 1].color = userColors[index].color;
                ScoreManager.Instance.AddPoints(index + 1);
                break;
        }
    }

    private void CleanColorDisplay()
    {
        Color fadedWhite = new Color(1f, 1f, 1f, 76f / 255f);
        for (int i = 0; i < userSelectedColors.Count; ++i)
        {
            userSelectedColors[i].color = fadedWhite;
        }
    }

    private IEnumerator IncorrectSequence()
    {
        
        foreach (var button in buttonsInteractions)
        {
            button.enabled = false;
        }
        
        for (int i = 0; i < 2; ++i)
        {
            foreach (var img in userSelectedColors)
            {
                img.color = Color.red;
            }
            yield return new WaitForSeconds(0.5f);
            CleanColorDisplay();
            yield return new WaitForSeconds(0.5f);
        }
        
        userSequence.Clear();
  
        foreach (var button in buttonsInteractions)
        {
            button.enabled = true;
        }
    }
}