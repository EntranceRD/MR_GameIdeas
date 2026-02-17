using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Sequence 
{
    public class FloorBoard : MonoBehaviour
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
        [SerializeField] private GeneralAnimator[] generalAnimators;
        //[SerializeField] private Ranking ranking;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            RestartAnimations();
            //ranking.Restart();
        }
        #endregion

        #region PRIVATE METHODS
        private void RestartAnimations()
        {
            for (int i = 0; i < generalAnimators.Length; i++)
            {
                generalAnimators[i].Restart();
            }
        }
        #endregion
    }
}