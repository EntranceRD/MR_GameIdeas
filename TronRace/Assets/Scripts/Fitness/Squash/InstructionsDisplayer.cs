using System.Collections;
using UnityEngine;

namespace Entrance.Games.Squash
{
    public class InstructionsDisplayer : MonoBehaviour
    {
        #region UNITY METHODS
        void Start()
        {

        }
        #endregion

        #region VARIABLES
        [Header("References")]
        [SerializeField] private GameObject[] countdowns;
        [SerializeField] private GeneralAnimator[] anims;

        [Header("Settings")]
        [SerializeField] private float displayInstructionsTime = 3f;
        [SerializeField] private float displayPlayersShapesTime = 3f;
        private float countdownTime = 3f;
        private bool displayingInstructions;
        public System.Action OnEndDisplaying;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            StopAllCoroutines();
            anims[0].SetAnimationStateValue(0);
            anims[1].SetAnimationStateValue(0);
            CountdownsState(false);
            displayingInstructions = false;
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
            anims[0].SetAnimationStateValue(2);
            yield return new WaitForSeconds(displayInstructionsTime);
            anims[0].SetAnimationStateValue(1);
            anims[1].SetAnimationStateValue(2);
            yield return new WaitForSeconds(displayPlayersShapesTime);
            CountdownsState(true);
            yield return new WaitForSeconds(countdownTime);
            anims[1].SetAnimationStateValue(1);
            displayingInstructions = true;
            OnEndDisplaying?.Invoke();
        }

        private void CountdownsState(bool state)
        {
            for (int i = 0; i < countdowns.Length; i++)
            {
                countdowns[i].SetActive(state);
            }
        }
        #endregion
    }
}