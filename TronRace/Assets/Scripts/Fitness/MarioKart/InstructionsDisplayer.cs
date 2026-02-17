using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Entrance.Games.MarioKart 
{
    public class InstructionsDisplayer : MonoBehaviour
    {
        #region VARIABLES
        [Header("References")]
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private GameObject[] countdowns;
        [SerializeField] private GameObject finishLine;
        [SerializeField] private RawImage videoTexture;
        [SerializeField] private TextMeshProUGUI instructionsTxt;

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
        #endregion
    }
}