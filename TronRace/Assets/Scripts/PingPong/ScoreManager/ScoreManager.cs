using Entrance;
using Entrance.Unity;
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

    public GameDifficulty[] difficultiesPerPlayers;

    private GameDifficulty currentDifficulty;
    private Timer spawnCoinTimer;
    private int currentPoints;
    private int currentSequences;
    private int times2Used;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI totalPoints;
    [SerializeField] private TextMeshProUGUI totalSequences;
    //[SerializeField] private TextMeshProUGUI totalX2;
    #endregion

    #region PUBLIC METHODS
    public void AddPoints(int points)
    {
        currentPoints += points;
        UpdateUI();
    }

    public void ApplyTimes2()
    {
        currentPoints *= 2;
        times2Used++;
        UpdateUI();
    }

    public void ShowCoinScore()
    {
        CollectCoins();
        UpdateUI();
    }
    public void SetPlayers(int totalPlayers)
    {
        //difficultyIndex = GetDifficultyAccordingToPlayersTotal(totalPlayers);
        //currentDifficulty = difficultiesPerPlayers[difficultyIndex];
    }

    public void PrepareGame()
    {
        spawnCoinTimer.OnFinish = () =>
        {
            //int newCoinValue = GetNewCoinValue();
            //SpawnNewCoinWithValue(newCoinValue);
        };
    }

    public void UpdateSequences(int amount)
    {
        currentSequences += amount;
        UpdateUI();
    }

    #endregion

    #region PRIVATE METHODS
    private void UpdateUI()
    {
        totalPoints.text = "Puntos: " + currentPoints.ToString();
        totalSequences.text = "Secuencias: " + currentSequences.ToString();
        //totalX2.text = times2Used.ToString();
    }
    private void CollectCoins()
    {
        Balloon[] ballons = FindObjectsOfType<Balloon>();
        foreach (Balloon coin in ballons)
        {
            currentPoints += coin.value;
        }
    }

    /*private int GetNewCoinValue()
    {
        for (int i = 0; i < currentDifficulty.settingsPerGamePlayers.Length; i++)
        {
            var coinSetting = currentDifficulty.settingsPerGamePlayers[i];
            if (coinSetting.totalCoins > 0)
            {
                currentDifficulty.settingsPerGamePlayers[i].totalCoins--;
                return coinSetting.coinValue;
            }
        }
    }*/
    #endregion
}