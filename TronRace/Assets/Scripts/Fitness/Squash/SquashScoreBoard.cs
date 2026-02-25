using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using EntranceGames.Squash;

namespace Entrance 
{
    public class SquashScoreBoard : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private TextMeshProUGUI playerID;
        public TextMeshProUGUI playerScore;
        #endregion

        #region PUBLIC METHODS
        public void InitializePlayer(string name, SquashBall ball)
        {
            playerID.text = name;
            ball.SetDisplay(playerScore);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}