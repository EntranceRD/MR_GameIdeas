using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance 
{
    //[RequireComponent(typeof(Image))]
    public class ImageAnimation : MonoBehaviour, IRestartable
    {
        #region UNITY METHODS
        private void Start()
        {
            //if (img == null) img = GetComponent<Image>();
            frequencyTimer.Target = 1.0f / frequency;
            frequencyTimer.OnFinish = () => {
                frequencyTimer.Restart();
                currentFrame = (currentFrame + 1) % frames.Length;
                ChangeSprite();
            };
            frequencyTimer.Restart();
        }

        private void Update()
        {
            if (!active) return;
            frequencyTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Image img;
        [SerializeField, Range(12, 60)] private int frequency = 60;
        private Timer frequencyTimer = new Timer();
        [SerializeField] private Sprite[] frames;
        private int currentFrame = 0;
        [SerializeField]private bool active = false;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            currentFrame = 0;
            frequencyTimer.Restart();
            active = false;
        }
        public void Play() {
            active = true;
        }
        public void Stop() { active = false; }
        #endregion

        #region PRIVATE METHODS
        private void ChangeSprite()
        {
            if (img == null) return;
            img.sprite = frames[currentFrame];
        }
        #endregion
    }
}