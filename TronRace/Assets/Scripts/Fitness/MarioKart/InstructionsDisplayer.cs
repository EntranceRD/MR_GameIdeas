using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Entrance.Games.MarioKart 
{
    public class InstructionsDisplayer : MonoBehaviour
    {
        #region UNITY METHODS
        void Start()
        {
            GameManager.Instance.OnGameStop -= GameOverScreen;
            GameManager.Instance.OnGameStop += GameOverScreen;
        }
        #endregion

        #region VARIABLES
        [Header("References")]
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private RawImage videoTexture;
        [SerializeField] private TextMeshProUGUI instructionsTxt;
        [SerializeField] private GameObject finishLine;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject[] countdowns;

        [Header("Settings")]
        [SerializeField] private float displayInstructionsTime = 3f;
        [SerializeField] private float countdownTime = 3f;
        private bool displayingInstructions;
        public System.Action OnEndDisplaying;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        { 
            StopAllCoroutines();
            InstructionsState(true);
            CountdownsState(false);
            finishLine.SetActive(false);
            gameOverPanel.SetActive(false);
            displayingInstructions = false;
        }

        public void DisplayInstructions()
        {
            if (displayingInstructions) { return; };
            displayingInstructions = true;
            StartCoroutine(ShowVideo());
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator ShowVideo()
        {
            videoPlayer.Play();
            yield return new WaitForSeconds(displayInstructionsTime);
            videoPlayer.Stop();
            CountdownsState(true);
            InstructionsState(false);
            yield return new WaitForSeconds(countdownTime);
            finishLine.SetActive(true);
            OnEndDisplaying?.Invoke();
        }

        private void CountdownsState(bool state)
        {
            for (int i = 0; i < countdowns.Length; i++)
            {
                countdowns[i].SetActive(state);
            }
        }

        private void InstructionsState(bool state)
        {
            videoTexture.gameObject.SetActive(state);   
            instructionsTxt.gameObject.SetActive(state);
        }

        private void GameOverScreen()
        {
            CountdownsState(false);
            InstructionsState(false);
            gameOverPanel.SetActive(true);
        }
        #endregion
    }
}