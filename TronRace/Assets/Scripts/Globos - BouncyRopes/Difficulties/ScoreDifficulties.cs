using System.Collections.Generic;
using UnityEngine;

public class ScoreDifficulties : MonoBehaviour
{
    [Range(2, 6)] public int numberOfPlayers;
    public int totalCoinsPerGame;
    [SerializeField] private List<int> possibleCoinValues = new List<int>();

    void Start()
    {
        ConfigureDifficulty(numberOfPlayers);
    }

    private void ConfigureDifficulty(int players)
    {
        possibleCoinValues.Clear();

        switch (players)
        {
            case 2:
                totalCoinsPerGame = 100;
                AddCoins(50, 1);
                AddCoins(50, 2); 
                break;

            case 3:
                totalCoinsPerGame = 100;
                AddCoins(40, 1);
                AddCoins(30, 2);
                AddCoins(30, 3);
                break;

            case 4:
                totalCoinsPerGame = 100;
                AddCoins(30, 1);
                AddCoins(30, 2);
                AddCoins(20, 3);
                AddCoins(20, 4);
                break;

            case 5:
                totalCoinsPerGame = 100;
                AddCoins(25, 2);
                AddCoins(25, 3);
                AddCoins(25, 4);
                AddCoins(25, 5);
                break;

            case 6:
                totalCoinsPerGame = 100;
                AddCoins(40, 2);
                AddCoins(30, 5);
                AddCoins(20, 10);
                break;
        }
    }

    private void AddCoins(int count, int value)
    {
        for (int i = 0; i < count; i++)
        {
            possibleCoinValues.Add(value);
        }
    }
}
