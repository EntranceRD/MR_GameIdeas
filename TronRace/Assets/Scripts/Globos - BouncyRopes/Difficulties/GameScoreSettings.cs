using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameScoreSettings
{
    [Range(1,20)]public int coinValue;
    [Range(5,60) ]public int totalCoins;
}

public class GameDifficulty : MonoBehaviour
{
    [SerializeField] // Permite editar desde el inspector
    public GameScoreSettings[] settingsPerGamePlayers02 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers03 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers04 = new GameScoreSettings[5];
    public GameScoreSettings[] settingsPerGamePlayers05 = new GameScoreSettings[5];

}
