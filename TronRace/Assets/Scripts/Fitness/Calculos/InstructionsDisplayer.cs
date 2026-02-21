using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Entrance.Games.Mathematics
{
    public class InstructionsDisplayer : MonoBehaviour
    {
        #region VARIABLES
        [Header("References")]
        [SerializeField] private GameObject[] countdowns;
        [SerializeField] private GeneralAnimator[] generalAnimators;

        [Header("Settings")]
        [SerializeField,Range(1,10)] private float displayInstructionsTime = 3f;
        [SerializeField,Range(1,10)] private float displayWarningsTime = 3f;
        [SerializeField] private float countdownTime = 3f;
        private bool displayingInstructions;
        public System.Action OnEndDisplaying;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            displayingInstructions = false;
            StopAllCoroutines();
            CountdownsState(false);
            RestartGeneralAnims();
        }

        public void DisplayInstructions()
        {
            if (displayingInstructions) { return; };
            displayingInstructions = true;
            StartCoroutine(ShowInstructions());
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator ShowInstructions()
        {
            GeneralAnimState(0,2);
            yield return new WaitForSeconds(displayInstructionsTime);
            GeneralAnimState(1,2);
            yield return new WaitForSeconds(displayWarningsTime);
            GeneralAnimState(0,1);
            GeneralAnimState(1,1);
            CountdownsState(true);
            yield return new WaitForSeconds(countdownTime);
            RestartGeneralAnims();
            OnEndDisplaying?.Invoke();
        }

        private void CountdownsState(bool state)
        {
            for (int i = 0; i < countdowns.Length; i++)
            {
                countdowns[i].SetActive(state);
            }
        }

        private void GeneralAnimState(int generalAnim, int state)
        {
            generalAnimators[generalAnim].SetAnimationStateValue(state);
        }

        private void RestartGeneralAnims()
        {
            for (int i = 0; i < generalAnimators.Length; i++)
            {
                generalAnimators[i].Restart();
            }
        }
        #endregion
    }
}