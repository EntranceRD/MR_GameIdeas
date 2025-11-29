using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int currentPoints;
    [SerializeField] private TextMeshProUGUI totalPoints;
    [SerializeField] private TextMeshProUGUI totalX2;

    [SerializeField] public static int Times2Count = 0;
    int Times2Used = 0;
    public static int MaxTimes2Allowed = 5;

    private void Start()
    {
        currentPoints = 0;
        Times2Count = 0;
    }

    public void AddPoints(int points)
    {
        currentPoints += points;
        Debug.Log("Puntos por gelatina destruida: " + points);
        UpdateUI();
    }

    public void AddPointsByRacket(int points)
    {
        currentPoints += points;
        //Debug.Log("Puntos por raqueta: " + points);
        UpdateUI();
    }

    public void ApplyTimes2()
    {
        currentPoints *= 2;
        Times2Used++;
        Debug.Log("Puntos doblados! Multiplicadores x2 usados: " + Times2Used);
        UpdateUI();
    }

    private void UpdateUI()
    {
        totalPoints.text = currentPoints.ToString();
        totalX2.text = Times2Used.ToString();
    }
}
