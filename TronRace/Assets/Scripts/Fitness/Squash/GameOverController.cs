using Entrance.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance.Games
{
    public class GameOverController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            OnGameOver = () =>
            {
                eventsOnGameOver.Call();
                audioSource.PlayOneShot(gameOverSound);
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
        public Action OnGameOver;

        [Header("Sound")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip gameOverSound;

        [SerializeField] private ButtonEvent eventsOnGameOver;
        [SerializeField] private GameObject[] gameOverDisplays;
        [SerializeField] private Image[] screensImages;
        private bool displaying = false;
        #endregion

        #region PUBLIC METHODS
        public void Display()
        {
            if (displaying) { return; };
            OnGameOver?.Invoke();
            OnStartDisplaying?.Invoke();
            ShowGameOverScreen();
        }

        public void Restart()
        {
            audioSource.Stop();
            foreach (var display in gameOverDisplays)
            {
                display.SetActive(false);
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void ShowGameOverScreen()
        {
            foreach (var display in gameOverDisplays)
            { 
                display.SetActive(true);
            }
            foreach (var image in screensImages)
            {
                image.color = Color.white;
            }
            OnFinishDisplaying?.Invoke();
        }
        #endregion
    }
}