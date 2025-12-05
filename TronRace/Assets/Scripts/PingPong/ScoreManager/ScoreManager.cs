using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region UNITY METHODS
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        currentPoints = 0;
        times2Used = 0;
        UpdateUI();
    }
    #endregion

    #region VARIABLES
    public static ScoreManager Instance { get; private set; }

    private int currentPoints;
    private int times2Used;

    [SerializeField] private TextMeshProUGUI totalPoints;
    [SerializeField] private TextMeshProUGUI totalX2;
    #endregion

    #region PUBLIC METHODS
    public void AddPoints(int points)
    {
        currentPoints += points;
        //Debug.Log("Puntos por gelatina destruida: " + points);
        UpdateUI();
    }

    public void ApplyTimes2()
    {
        currentPoints *= 2;
        times2Used++;
        //Debug.Log("Puntos doblados! Multiplicadores x2 usados: " + times2Used);
        UpdateUI();
    }
    #endregion

    #region PRIVATE METHODS
    private void UpdateUI()
    {
        totalPoints.text = currentPoints.ToString();
        totalX2.text = times2Used.ToString();
    }
    #endregion
}