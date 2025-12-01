using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PingPongPallet : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnTriggerEnter(Collider other)
        {
            var ball = other.GetComponent<PingPongBall>();
            if(ball!=null){
                ball.ChangeMovingDirection();
                ball.BounceRandom(angleGenerator);
                scoreManager.AddPoints(pointHit);
            }
        }
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private RandomAngleGenerator angleGenerator;
        [SerializeField] private ScoreManager scoreManager;
        int pointHit = 1;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}