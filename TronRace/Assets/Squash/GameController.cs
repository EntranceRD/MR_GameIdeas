using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Squash 
{
    public class GameController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            PrepareGame();
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField, Range(1, 6)] private int totalPlayers = 3;
        [SerializeField] private SquashPlayer[] players;
        [SerializeField] private GameObject blocker;
        public Score[] scores;
        public SquashUI_PlayerData[] playersUI;
        private int hardPlayers = 10;
        #endregion

        #region PUBLIC METHODS
        public void PrepareUsers_1_6() {
            var max = Mathf.Min(6, hardPlayers);
            totalPlayers = max;
            for (int i = 0; i < max; i++)
            {
                players[i].score = scores[i];
            }
            for (int i = max; i < 6; i++)
            {
                players[i].Hide();
            }

            for (int i = 0; i < 6; ++i) {
                playersUI[i].Play();
            }
            for (int i = 6; i < 12; ++i)
            {
                playersUI[i].Rest();
            }
        }
        public void PrepareUsers_7_12()
        {
            var max = Mathf.Min(12, hardPlayers);
            totalPlayers = max - 6;
            for (int i = 6; i < max; i++)
            {
                players[i-6].score = scores[i];
            }
            for (int i = totalPlayers; i < 6; i++)
            {
                players[i].Hide();
            }

            for (int i = 0; i < 6; ++i)
            {
                playersUI[i].Rest();
            }
            for (int i = 6; i < 12; ++i)
            {
                playersUI[i].Play();
            }
        }
        public void PrepareGame() {
            blocker.SetActive(true);
            foreach (var player in players) { 
                player.Prepare();
            }
            WriteUsernames();
        }

        public void Restart() {
            var totalGameBalls = GetBallsForGame();
            foreach (var player in players) { 
                //player.SetGameTargetScore(maxScore);
                player.HideGameElements();
            }
            for (int i = 0; i < totalPlayers; i++)
            {
                players[i].Restart();
                players[i].SetTotalBalls(totalGameBalls);
            }
            blocker.SetActive(false);

        }
        public void FinishGame()
        {
            foreach (var player in players) {
                player.HideGameElements();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private int GetBallsForGame()
        {
            switch (totalPlayers) {
                case 1:
                case 2:
                case 3:
                    return 2;
                default:return 1;
            }
        }
        private void WriteUsernames() {
            foreach (var player in playersUI) {
                player.Hide();
            }

            var usernames = new string[] { 
                "AAA",
                "BBB",
                "CCC",
                "DDD",
                "EEE",
                "FFF",
                "GGG",
                "HHH",
                "III",
                "JJJ",
                "KKK",
                "LLL",
            };
            for (int i = 0; i < usernames.Length; i++)
            {
                playersUI[i].Initialize( usernames[i]);
                playersUI[i].Show();
            }
        }
        #endregion
    }
}