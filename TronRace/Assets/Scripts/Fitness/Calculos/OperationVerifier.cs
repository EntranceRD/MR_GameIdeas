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
                possibleResultsBtns[i].OnClick += () =>
                {
                    VerifyAnswer(possibleResultsBtns[idx]);
                };
            }
        }
        #endregion

        #region VARIABLES
        public Action OnOperationVerified;

        [Header("References")]
        [SerializeField] private OptionButton[] possibleResultsBtns;
        [SerializeField] private SoundManager soundManager;

        [Header("Settings")]
        public int pointsForSolvedOperation = -1;
        public int correctResultIndex = -1;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            correctResultIndex = -1;
            pointsForSolvedOperation = -1;
            soundManager.StopSounds();
        }
        #endregion

        #region PRIVATE METHODS
        private void VerifyAnswer(OptionButton btn)
        {
            if (correctResultIndex != btn.contextIndex)
            {
                btn.ChangeColor(Color.red);
                soundManager.PlaySound(1);
                return;
            }
            btn.ChangeColor(Color.green);
            soundManager.PlaySound(0);
            OnOperationVerified?.Invoke();
        }
        #endregion
    }
}