using Entrance.Games.Mathematics;
using Entrance.Unity;
using UnityEngine;

namespace Entrance.Games.Mathematics
{
    public class MiddleButton : MonoBehaviour
    {
        //public Timer releasedTimer;
        public MathBoardManager gameManagerBoard;
        //[SerializeField] public bool playerReleased = false;
        //[SerializeField] private bool timerFinish = false;

        void Start()
        {
            //releasedtimer.onfinish -= checkclickedbuttons;
            //releasedtimer.onfinish += checkclickedbuttons;
            //releasedtimer.restart();
        }

        //void Update()
        //{
        //    if (playerReleased)
        //    {
        //        releasedTimer.Tick(Time.deltaTime);
        //    }
        //}

        //private void FixedUpdate()
        //{
        //    if (timerFinish)
        //    {
        //        CheckClickedButtons();
        //    }
        //}

        public void Restart()
        {
            gameObject.SetActive(false);
            //playerReleased = false;
            //timerFinish = false;
            //releasedTimer.Restart();
        }

        //public void PlayerReleased()
        //{
        //    playerReleased = true;
        //}

        public void CheckClickedButtons()
        {
            //timerFinish = true;
            //releasedTimer.Restart();
            if (gameManagerBoard.CheckAllPlayersInButtons())
            {
                gameManagerBoard.NewRound();
                gameObject.SetActive(false);
            }
        }
    }
}