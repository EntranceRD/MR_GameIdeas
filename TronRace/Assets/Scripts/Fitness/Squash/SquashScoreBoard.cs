using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using Entrance.Games;

namespace Entrance.Games.Squash
{
    public class SquashScoreBoard : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            scoreController.OnPointsChanged -= DisplayScore;
            scoreController.OnPointsChanged += DisplayScore;
            //ball.scoreManager.OnPointsChanged += () =>
            //{
            //    scoreTextDisplayer.UpdateUI(ball.scoreManager.currentPoints);
            //    StartCoroutine(Blink(blinkTime, blinkTimes));
            //};
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        [SerializeField] private TextMeshProUGUI playerID;
        [SerializeField] private MaterialController materialController;
        [SerializeField] private ScoreTextDisplayer scoreTextDisplayer;
        [SerializeField] private float blinkTime = 0.2f;
        [SerializeField] private int blinkTimes = 2;
        [SerializeField] private ScoreController scoreController;
        [SerializeField] private Color boardColor;
        [SerializeField] private Color transparentBoardColor;

        //public TextMeshProUGUI playerScore;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            StopAllCoroutines();
            playerID.text = "";
            scoreTextDisplayer.Restart();
        }


        public void Blink()
        {
            StartCoroutine(blink(blinkTime, blinkTimes));
        }
        public void Initialize(string name, Color color) {
            playerID.text = name;
            boardColor = color;
            color.a = .5f;
            transparentBoardColor = color;
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator blink(float blinkTime, int times)
        {
            for (int i = 0; i < times; i++)
            {
                materialController.ChangeColor(boardColor);
                yield return new WaitForSeconds(blinkTime);
                materialController.ChangeColor(transparentBoardColor);
                yield return new WaitForSeconds(blinkTime);
            }
            materialController.ChangeColor(Color.black);
        }
        private void DisplayScore(int score) {
            Blink();
            scoreTextDisplayer.UpdateDisplayWithValue(score);
        }
    #endregion
    }
}
