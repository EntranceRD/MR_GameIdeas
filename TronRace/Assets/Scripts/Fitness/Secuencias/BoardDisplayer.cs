using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Sequence
{
    public class BoardDisplayer : MonoBehaviour
    {
        public void Awake()
        {
            SetGameOverPanel(false);
        }

        private void Start()
        {
            //GameManager.Instance.OnGameStop -= GameOver;
            //GameManager.Instance.OnGameStop += GameOver;
            displayer.OnFinishDisplaying = ()=> {
                ActiveWaitPanel(false);
            };
        }

        #region VARIABLES
        [Header("References")]
        [SerializeField] private SequenceDisplayer displayer;
        [SerializeField] private SequenceButton[] sequenceButtons;

        [Header("Covers")]
        [SerializeField] private List<GameObject> coverPanels = new List<GameObject>();
        [SerializeField] private List<GameObject> gameOver = new List<GameObject>();

        [Header("Settings")]
        [SerializeField] private float initialWaitTime = 3f;
        #endregion

        #region PUBLIC METHODS
        public void ReDisplaySequence(List<int> sequence)
        {
            StartSequence(sequence);
        }

        public void Restart()
        {
            //InitializeButtonsColors();
            ActiveWaitPanel(false);
            StopAllCoroutines();
            SetGameOverPanel(false);
            displayer.Restart();
            displayer.OnDisplayElement -= DisplaySequenceIndex;
            displayer.OnDisplayElement += DisplaySequenceIndex;
            displayer.OnFinishDisplaying -= EnableAllButtons;
            displayer.OnFinishDisplaying += EnableAllButtons;
        }

        public void StartSequence(List<int> sequence)
        {
            StartCoroutine(DisplayGameInstructions(sequence));
        }

        public void InitializeButtonsColors(ColorData[]colors)
        {
            for (int i = 0; i < sequenceButtons.Length; i++)
            {
                sequenceButtons[i].InitializeColor(colors[i].color);
                //sequenceButtons[i].InitializeColor(ColorSequence.Instance.colors[i].color);
            }
        }

        #endregion

        #region PRIVATE METHODS   
        private IEnumerator DisplayGameInstructions(List<int> sequence)
        {
            ActiveWaitPanel(true);
            yield return new WaitForSeconds(initialWaitTime);
            DisplaySequence(sequence);
            //ActiveWaitPanel(false);
        }

        private void DisplaySequence(List<int> sequence)
        {
            SetButtonsInteraction(false);
            //yield return new WaitForSeconds(initialWaitTime);
            displayer.DisplaySequence(sequence);
        }

        private void ActiveWaitPanel(bool state)
        {
            for (int i = 0; i < coverPanels.Count; ++i)
            {
                coverPanels[i].SetActive(state);
            }
        }

        private void DisplaySequenceIndex(int buttonIndex, int index)
        {
            sequenceButtons[buttonIndex].InitializeIndex(index);
        }

        private void SetButtonsInteraction(bool state)
        {
            for (int i = 0; i < sequenceButtons.Length; i++)
            {
                sequenceButtons[i].SetInteraction(state);
            }
        }
        private void EnableAllButtons() { SetButtonsInteraction(true); }

        private void DisableAllButtons() { SetButtonsInteraction(false); }

        public void GameOver()
        {
            displayer.ForceStop();
            ActiveWaitPanel(false);
            SetGameOverPanel(true);
            DisableAllButtons();
        }

        private void SetGameOverPanel(bool state)
        {
            for (int i = 0; i < gameOver.Count; ++i)
            {
                gameOver[i].SetActive(state);
            }
        }
        #endregion
    }
}