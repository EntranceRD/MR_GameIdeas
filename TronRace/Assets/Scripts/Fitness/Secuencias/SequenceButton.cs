using Entrance;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Entrance.Games.Sequence
{
    public interface IHighlightableObject
    {
        void Highlight(float time);
    }

    public class SequenceButton : MonoBehaviour, IHighlightableObject
    {
        public AudioSource audioSource;
        public MaterialController materialController;
        public Collider interactionCollider;

        public TextMeshProUGUI indexTxt;

        public void Restart()
        {
            indexTxt.text = string.Empty;
            var txtColor = indexTxt.color;
            txtColor.a = 0f;
            indexTxt.color = txtColor;
        }

        public void SetInteraction(bool state)
        {
            interactionCollider.enabled = state;
        }

        public void Blink(float blinkTime, int times)
        {
            StartCoroutine(blink(blinkTime, times));
        }

        public void InitializeColor(Color color)
        {
            var fadedColor = color * .45f;
            materialController.SetColors(new Color[] { color, fadedColor, Color.red, Color.black });
            materialController.ChangeColor(1);
        }

        public void InitializeIndex(int index)
        {
            indexTxt.text = $"{index + 1}";
        }

        public void Highlight(float time)
        {
            PlaySound();
            StartCoroutine(highlight(time));
        }

        public void PlaySound()
        {
            audioSource.Play();
        }

        private IEnumerator highlight(float time)
        {
            materialController.ChangeColor(0);
            var txtColor = indexTxt.color;
            txtColor.a = 1f;
            indexTxt.color = txtColor;
            yield return new WaitForSeconds(time);
            indexTxt.text = string.Empty;
            materialController.ChangeColor(1);
        }



        private IEnumerator blink(float blinkTime, int times)
        {
            for (int i = 0; i < times; i++)
            {
                materialController.ChangeColor(2);
                yield return new WaitForSeconds(blinkTime);
                materialController.ChangeColor(3);
                yield return new WaitForSeconds(blinkTime);
            }
            materialController.ChangeColor(1);
        }
    }
}