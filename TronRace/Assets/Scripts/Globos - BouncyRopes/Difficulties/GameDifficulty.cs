using Entrance;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static GameDifficulty Instance { get; private set; }

    public GameScoreSettings[] settingsPerGamePlayers02 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers03 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers04 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers05 = new GameScoreSettings[5];
    
    GameScoreSettings[] currentCoinSettings;

    [Range(2,5)]public int totalPlayers;
    public GameObject coinPrefab;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializeSettingsForTotalPLayers(totalPlayers);
    }

    private void InitializeSettingsForTotalPLayers(int totalPlayers)
    {
        switch (totalPlayers)
        {
            case 2:
                currentCoinSettings = settingsPerGamePlayers02;
                break;
            case 3:
                currentCoinSettings = settingsPerGamePlayers03;
                break;
            case 4:
                currentCoinSettings = settingsPerGamePlayers04;
                break;
            case 5:
                currentCoinSettings = settingsPerGamePlayers05;
                break;
            default:
                currentCoinSettings = settingsPerGamePlayers02;
                break;
        }
    }

    public int NewCoinValue()
    {
        //var coin = Instantiate(coinPrefab).GetComponent<Balloon>();
        //coin.value = GetRandomCoinValueForPlayers(totalPlayers);
        //return GetRandomCoinValueForPlayers(totalPlayers);

        for(int i = 0; i < 10; i++)
        {
            var rand = Random.Range(0, currentCoinSettings.Length);
            var coinSetting = currentCoinSettings[rand];
            if(coinSetting.totalCoins > 0)
            {
                coinSetting.totalCoins--;
                return coinSetting.coinValue;
            }
        }

        for (int i = 0; i < currentCoinSettings.Length; i++)
        {
            var coinSetting = currentCoinSettings[i];
            if(coinSetting.totalCoins > 0)
            {
                coinSetting.totalCoins--;
                return coinSetting.coinValue;
            }
        }

        return -1;
    }

    /*public int GetRandomCoinValueForPlayers(int totalPlayers)
    {

        //var random = Random.Range(0, currentCoinSettings.Length);
        List<int> available = new List<int>();

        for (int i = 0; i < currentCoinSettings.Length; i++)
        {
            if (currentCoinSettings[i].totalCoins > 0)
                available.Add(i);
        }

        if (available.Count == 0)
        {
            Debug.LogWarning("No quedan monedas disponibles");
            return 0;
        }

        int randomIndex = available[Random.Range(0, available.Count)];
        currentCoinSettings[randomIndex].totalCoins--;
        return currentCoinSettings[randomIndex].coinValue;
    }*/
}
