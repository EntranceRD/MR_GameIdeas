using System.Collections;
using UnityEngine;

namespace Entrance.Games.Squash
{
    public class InstructionsDisplayer : MonoBehaviour
    {
        #region UNITY METHODS
        void Start()
        {
            OnEndDisplaying -= ShowScoreBoards;
            OnEndDisplaying += ShowScoreBoards;
        }
        #endregion

        #region VARIABLES
        [Header("References")]
        [SerializeField] private GameObject[] countdowns;
        [SerializeField] private GameObject[] gameOverScreens;
        [SerializeField] private GeneralAnimator[] texts;
        [SerializeField] private GeneralAnimator[] scoreBoards;

        [Header("Settings")]
        [SerializeField] private float displayInstructionsTime = 3f;
        [SerializeField] private float displayPlayersShapesTime = 3f;
        private float countdownTime = 3f;
        private bool displayingInstructions;
        public System.Action OnEndDisplaying;
        public System.Action OnEndInstructions;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            StopAllCoroutines();
            CountdownsState(false);
            GameOverScreenState(false);
            displayingInstructions = false;
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i].Restart();    
            }
            for (int i = 0; i < scoreBoards.Length; i++)
            {
                scoreBoards[i].Restart();    
            }
        }

        public void Display()
        {
            if (displayingInstructions) { return; };
            displayingInstructions = true;
            StartCoroutine(ShowInstructions());
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator ShowInstructions()
        {
            yield return new WaitForSeconds(countdownTime);
            texts[0].SetAnimationStateValue(2);
            yield return new WaitForSeconds(displayInstructionsTime);
            texts[0].SetAnimationStateValue(1);
            texts[1].SetAnimationStateValue(2);
            OnEndInstructions?.Invoke();
            yield return new WaitForSeconds(displayPlayersShapesTime);
            CountdownsState(true);
            yield return new WaitForSeconds(countdownTime);
            texts[1].SetAnimationStateValue(1);
            displayingInstructions = true;
            OnEndDisplaying?.Invoke();
        }

        private void ShowScoreBoards()
        {
            for (int i = 0; i < scoreBoards.Length; i++)
            {
                scoreBoards[i].SetAnimationStateValue(2);
            }
        }

        private void CountdownsState(bool state)
        {
            for (int i = 0; i < countdowns.Length; i++)
            {
                countdowns[i].SetActive(state);
            }
        }

        private void GameOverScreenState(bool state)
        {
            for (int i = 0; i < gameOverScreens.Length; i++)
            {
                gameOverScreens[i].SetActive(state);
            }
        }
        #endregion
    }
}