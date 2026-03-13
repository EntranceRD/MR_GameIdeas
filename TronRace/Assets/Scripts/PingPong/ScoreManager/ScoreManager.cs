using TMPro;
using UnityEngine;

namespace Entrance
{
    public class ScoreController : MonoBehaviour
    {
        public ScoreController()
        {
            score = new Counter();
        }
        public Counter score { get; protected set; }    
    
        #region VARIABLES
        public int currentPoints { get { return (int)score; } }
        public System.Action<int> OnPointsChanged;

        #endregion

        #region PUBLIC METHODS

        public void Restart()
        {
            score.Restart();
        }

        public void AddPoints(int points)
        {
            score.Add(points);
            OnPointsChanged?.Invoke(currentPoints);
        }
        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}



//private void CollectCoins()
//{
//    Balloon[] ballons = FindObjectsOfType<Balloon>();
//    foreach (Balloon coin in ballons)
//    {
//        currentPoints += coin.value;
//    }
//}

///*private int GetNewCoinValue()
//{
//    for (int i = 0; i < currentDifficulty.settingsPerGamePlayers.Length; i++)
//    {
//        var coinSetting = currentDifficulty.settingsPerGamePlayers[i];
//        if (coinSetting.totalCoins > 0)
//        {
//            currentDifficulty.settingsPerGamePlayers[i].totalCoins--;
//            return coinSetting.coinValue;
//        }
//    }
//}*/
//public void PrepareGame()
//{
//    spawnCoinTimer.OnFinish = () =>
//    {
//        //int newCoinValue = GetNewCoinValue();
//        //SpawnNewCoinWithValue(newCoinValue);
//    };
//}

//public void UpdateSequences(int amount)
//{
//    currentSequences += amount;
//    UpdateUI();
//}
//public void ApplyTimes2()
//{
//    currentPoints *= 2;
//    times2Used++;
//    UpdateUI();
//}

//public void ShowCoinScore()
//{
//    CollectCoins();
//    UpdateUI();
//}
//public void SetPlayers(int totalPlayers)
//{
//    //difficultyIndex = GetDifficultyAccordingToPlayersTotal(totalPlayers);
//    //currentDifficulty = difficultiesPerPlayers[difficultyIndex];
//}
//private GameDifficulty currentDifficulty;
//private Timer spawnCoinTimer;
//private int currentSequences;
//private int times2Used;
//public static ScoreManager Instance { get; private set; }