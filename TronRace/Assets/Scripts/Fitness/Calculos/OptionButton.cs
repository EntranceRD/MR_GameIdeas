using System;
using TMPro;
using UnityEngine;
using Entrance.Unity;
using UnityEngine.UI;

namespace Entrance.Games.Mathematics
{
    [RequireComponent(typeof (ClickableElement))]

    public class OptionButton : MonoBehaviour
    {
        private void Awake()
        {
            //rend = GetComponent<Renderer>();
            //var originalColor = rend.material.color;
            image = GetComponent<Image>();
            var originalColor = image.color;

            myButton = GetComponent<ClickableElement>();
            myButton.OnClick.AddAction(() =>
            {
                OnClick?.Invoke();
            });
            changeColorTimer.OnFinish += () =>
            {
                ChangeColor(originalColor);
            };
        }

        private void FixedUpdate()
        {
            changeColorTimer.Tick(Time.fixedDeltaTime);
        }

        public MaterialController colorController;
        public TMP_Text buttonText;
        public int contextIndex = -1;
        public Action OnClick;
        //public Renderer rend;
        public Image image;
        private ClickableElement myButton;
        public Timer changeColorTimer;

        public void Restart()
        {
            ChangeColor(image.color);
            buttonText.text = string.Empty;
            contextIndex = -1;
        }

        public void Initialize<T>(int index, T textValue)
        {
            contextIndex = index;
            buttonText.text = textValue.ToString();
        }

        public void ChangeColor(Color newColor)
        {
            colorController.ChangeColor(newColor);
            changeColorTimer.Restart();
        }
    }
}