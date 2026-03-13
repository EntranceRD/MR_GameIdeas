using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Coins 
{
    public class CoinTeamBoard : MonoBehaviour
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
        [SerializeField] private ScoreController scoreController;
        [SerializeField] private BalloonInstantiator instantiator;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            scoreController.Restart();
        }

        public int GetScore()
        {
            var coinsList = instantiator.GetRemainingCoins();
            for (int i = 0; i < coinsList.Count; i++)
            {
                var coin = coinsList[i].GetComponent<Balloon>();
                if(coin != null)
                {
                    scoreController.AddPoints(coin.value);
                }
            }
            return scoreController.currentPoints;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}