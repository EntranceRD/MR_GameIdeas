using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entrance.UI;

namespace Entrance.Games
{
    public class InstructionsDisplayer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            OnStartDisplaying = () => { 
                displayingInstructions = true; 
                eventsOnStartDisplay.Call();
            };

            OnFinishDisplaying = () => { 
                displayingInstructions = false;
                eventsAfterDisplay.Call();
            };
        }

        private void Start()
        {

        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        public Action OnStartDisplaying;
        public Action OnFinishDisplaying;

        [Header("Sound")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip countdownSound;

        [Header("Countdown")]
        [SerializeField] private GameObject[] countdowns;
        [SerializeField] private Display_Text[] displayTexts;

        [Header("Settings")]
        [SerializeField] private float displayTime;
        [SerializeField] private ButtonEvent eventsOnStartDisplay;
        [SerializeField] private ButtonEvent eventsDuringDisplay;
        [SerializeField] private ButtonEvent eventsAfterDisplay;
        private bool displayingInstructions = false;
        private float countdownsTime = 3f;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            StopAllCoroutines();
            CountdownsState(false);
            displayingInstructions = false;
            audioSource.Stop();
            foreach (var text in displayTexts)
            {
                text.Restart();
            }
        }

        public void Display(bool oneByOne)
        {
            if (displayingInstructions) { return; };
            OnStartDisplaying?.Invoke();
            StartCoroutine(ShowInstructions(oneByOne));
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator ShowInstructions(bool oneByOne)
        {
            if (oneByOne)
            {
                float eachTime = displayTime / displayTexts.Length;

                eventsDuringDisplay.Call();
                foreach (var text in displayTexts)
                {
                    text.Show();
                    yield return new WaitForSeconds(eachTime);
                    text.Hide();
                }
            }
            else
            {
                eventsDuringDisplay.Call();
                foreach (var text in displayTexts)
                    text.Show();

                yield return new WaitForSeconds(displayTime);
            }

            foreach (var text in displayTexts)
                text.Hide();

            DisplayCountdowns(true, countdownSound);
            yield return new WaitForSeconds(countdownsTime);

            OnFinishDisplaying?.Invoke();
        }

        private void DisplayCountdowns(bool state, AudioClip sound)
        {
            CountdownsState(state);
            audioSource.PlayOneShot(sound);
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