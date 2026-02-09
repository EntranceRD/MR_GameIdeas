using Entrance.Games.Sequence;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Sequence
{
    public class ColorBoard : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            SetButtonsInteraction(false);
        }

        private void Start()
        {
            GameManager.Instance.OnGameStop -= GameStop;
            GameManager.Instance.OnGameStop += GameStop;
        }
        #endregion

        #region VARIABLES
        [Header("References")]
        public BoardDisplayer boardDisplayer;
        [SerializeField] private SoundManager soundManager;
        [SerializeField] private ScoreManager scoreManager;
        public SequenceComparer sequenceComparer { get; private set; }

        [Header("Settings")]
        [SerializeField] private SequenceButton[] userButtons;
        public int finalPoints;

        private List<int> userSequence = new List<int>();
        private List<int> correctSequence = new List<int>();
        #endregion

        #region PUBLIC METHODS

        public void Restart()
        {
            scoreManager.Restart();
            boardDisplayer.Restart();
            RestartSequenceButtons();
            RestartUserSequence();
        }

        public void InitializeBoard(List<int> sequence)
        {
            SetButtonsInteraction(true);
            correctSequence = sequence;
            if (sequenceComparer == null)
                sequenceComparer = new SequenceComparer();
            sequenceComparer.OnSequenceCompareResult -= OnSequenceComparasionResult;
            sequenceComparer.OnSequenceCompareResult += OnSequenceComparasionResult;
        }
        public void AddIndexToSequence(int buttonIndex)
        {
            userSequence.Add(buttonIndex);
            sequenceComparer?.CompareSequence(userSequence, correctSequence);

        }
        public void CleanBoard()
        {
            RestartSequenceButtons();
            RestartUserSequence();
        }

        public void GameStop()
        {
            SetButtonsInteraction(false);
            finalPoints = scoreManager.currentPoints;
        }
        #endregion

        #region PRIVATE METHODS

        private void RestartSequenceButtons()
        {
            for (int i = 0; i < userButtons.Length; i++)
            {
                userButtons[i].Restart();
            }
        }

        private void RestartUserSequence()
        {
            userSequence.Clear();
        }

        private void SetButtonsInteraction(bool state)
        {
            for (int i = 0; i < userButtons.Length; i++)
            {
                userButtons[i].SetInteraction(state);
            }
        }
        private void OnSequenceComparasionResult(SequenceComparisonResult result)
        {
            switch (result)
            {
                case SequenceComparisonResult.Correct:

                    var lastButtonIndex = correctSequence.Count - 1;
                    CorrectButtonActions(correctSequence[lastButtonIndex]);
                    CorrectSequence();
                    CleanBoard();
                    GameManager.Instance.BoardGuessRightSequence(this);
                    break;

                case SequenceComparisonResult.Incorrect:

                    IncorrectSequence();
                    break;

                case SequenceComparisonResult.Incomplete:

                    var buttonIndex = correctSequence[userSequence.Count - 1];
                    CorrectButtonActions(buttonIndex);
                    userButtons[buttonIndex].PlaySound();
                    break;
            }
        }
        private void CorrectSequence()
        {
            soundManager.PlaySound(0);
            for (int i = 0; i < userButtons.Length; i++)
            {
                userButtons[i].Highlight(1);
            }

        }

        private void IncorrectSequence()
        {
            SetButtonsInteraction(false);
            soundManager.PlaySound(1);
            for (int i = 0; i < userButtons.Length; i++)
            {
                userButtons[i].Blink(0.5f, 2);
            }
            userSequence.Clear();
            SetButtonsInteraction(true);
            boardDisplayer.ReDisplaySequence(correctSequence);
        }

        private void CorrectButtonActions(int buttonIndex)
        {
            scoreManager.AddPoints(buttonIndex + 1);
            userButtons[buttonIndex].Highlight(1f);
        }
        #endregion
    }
}