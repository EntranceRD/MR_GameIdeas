public class GameScoreSettings
{
    public int coinValue = 0;
    public int totalCoins = 0;
}

public class GameDifficulty
{
    public GameScoreSettings[] settingsPerGamePlayers;

    public GameDifficulty()
    {
        settingsPerGamePlayers = new GameScoreSettings[5]
        {
            new GameScoreSettings() { coinValue = 1, totalCoins = 20 },
            new GameScoreSettings() { coinValue = 2, totalCoins = 15 },
            new GameScoreSettings() { coinValue = 5, totalCoins = 10 }, 
            new GameScoreSettings() { coinValue = 10, totalCoins = 5 },
            new GameScoreSettings() { coinValue = 20, totalCoins = 1 }  
        };
    }
}