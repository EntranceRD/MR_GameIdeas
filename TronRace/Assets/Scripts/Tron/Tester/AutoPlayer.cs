using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Tron
{
    public class AutoPlayer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            decisionTimer = new Timer() {
                Target = 0.5f,
                OnFinish = () => {
                    DecideBehaviour();
                    decisionTimer.Restart();
                }
            };
            decisionTimer.Restart();
        }

        private void Update()
        {
            if (lifePlayer.isAlive()) { 
                decisionTimer.Tick(Time.deltaTime);
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private PlayerController player;
        [SerializeField] private TronPlayer lifePlayer;
        private Timer decisionTimer;
        private int ChanceToTurn = 10;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void DecideBehaviour()
        {
            var rand = Random.Range(0, 100);
            if (rand <= ChanceToTurn)
            {
                //turn left
                if ((rand % 2) == 1) { player.TurnLeft(); }
                //turn right
                else { player.TurnRight(); }
                //reset chance to turn
                ChanceToTurn = 10;
                //ChanceToTurn = Mathf.Max(10, ChanceToTurn - 10);
            }
            else {
                ChanceToTurn = Mathf.Min(50, ChanceToTurn + 5);
                //ChanceToTurn += 5;
            }
        }
        #endregion
    }
}