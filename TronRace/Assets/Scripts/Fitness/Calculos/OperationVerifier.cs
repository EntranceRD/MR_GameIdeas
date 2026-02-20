using Entrance.Games.Mathematics;
using System;
using UnityEngine;

namespace Entrance.Games.Mathematics
{
    public class OperationVerifier : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            for (int i = 0; i < possibleResultsBtns.Length; i++)
            {
                int idx = i;
                possibleResultsBtns[i].OnClick += () => {
                    VerifyAnswer(possibleResultsBtns[idx]);
                };
            }
        }
        #endregion

        #region VARIABLES
        public OptionButton[] possibleResultsBtns;
        public int correctResultIndex = -1;
        public int pointsForSolvedOperation = -1;
        //private MathOperation operationController;
        //public ScoreManager scoreManager;
        public Action OnOperationVerified;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            correctResultIndex = -1;
            pointsForSolvedOperation = -1;
            //scoreManager.Restart();
        }
        #endregion

        #region PRIVATE METHODS
        private void VerifyAnswer(OptionButton btn)
        {
            if (correctResultIndex != btn.contextIndex)
            {
                btn.ChangeColor(Color.red);
                return;
            }

            //pointsForSolvedOperation = operationController.Operators.Count;
            //scoreManager.AddPoints(pointsForSolvedOperation);
            btn.ChangeColor(Color.green);
            OnOperationVerified?.Invoke();
            //gameManagerBoard.middleButton.gameObject.SetActive(true);
            //gameManagerBoard.LockOptionButtons();
        }
        #endregion
    }
}