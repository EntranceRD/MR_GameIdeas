using UnityEngine;

[System.Serializable]
public class GameScoreSettings
{
    [Range(1,20)] public int coinValue;
    [Range(5,60)] public int totalCoins;
}
