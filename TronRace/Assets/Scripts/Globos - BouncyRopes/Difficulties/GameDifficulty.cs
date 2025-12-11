using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    public static GameDifficulty Instance { get; private set; }

    public GameScoreSettings[] settingsPerGamePlayers02 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers03 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers04 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers05 = new GameScoreSettings[5];
    
    GameScoreSettings[] currentCoinSettings;

    public int totalPlayers;
    public GameObject coinPrefab;

    private void Awake()
    {
        Instance = this;
    }

    public int NewCoinValue()
    {
        //var coin = Instantiate(coinPrefab).GetComponent<Balloon>();
        //coin.value = GetRandomCoinValueForPlayers(totalPlayers);
        return GetRandomCoinValueForPlayers(totalPlayers);
    }

    public int GetRandomCoinValueForPlayers(int totalPlayers)
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
        var random = Random.Range(0, currentCoinSettings.Length);
        return currentCoinSettings[random].coinValue;
    }
}
