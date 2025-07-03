using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash 
{
    public class SquashPlayer : MonoBehaviour
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
        public BallSpeedRegistry speeds;
        public SquashBall[] balls;
        public Score score;

        private int level = 0;
        #endregion

        #region PUBLIC METHODS
        public void Prepare() {
            foreach (var ball in balls)
            {
                ball.SetSpeed(0);
                ball.Prepare();
            }
        }
        public void SetTotalBalls(int total) {
            for (int i = 0; i < balls.Length; i++)
            {
                var enabled = i < total;
                if (enabled) { balls[i].Show(); }
                else { balls[i].Hide(); }
            }
        }
        public void HideGameElements() {
            foreach (var ball in balls) {
                ball.Hide();
            }
        }
        public void Hide()
        {
            foreach (var ball in balls)
            {
                ball.Hide();
            }
        }
        public void Restart()
        {
            level = 0;
            UpdateBallsSpeed();
            foreach (var ball in balls) {
                ball.Show();
                ball.Restart();
            }
        }
        public void CaptureBall()
        {
            level++;
            UpdateBallsSpeed();
            score.AddScore();
        }
        #endregion

        #region PRIVATE METHODS
        private void UpdateBallsSpeed()
        {
            var speed = speeds.GetSpeed(level);
            foreach (var ball in balls)
            {
                ball.SetSpeed(speed);
            }
        }
        #endregion
    }
}