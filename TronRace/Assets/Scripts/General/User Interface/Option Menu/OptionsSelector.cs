using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    [System.Serializable]
    public class OptionsSelector
    {
        #region VARIABLES
        [Header("Highlight")]
        public Color Selection=Color.cyan;
        public Color Normal = Color.white;
        [Space]
        public Color SelectedText = Color.cyan;
        public Color NormalText = Color.white;
        [Space]
        public Sprite SelectionBkg;
        public Sprite NormalBkg;
        [Space]
        public OptionElement[] options;
        public bool selected { get; protected set; } = false;
        public int SelectedIndex { get; protected set; } = -1;
        public OptionElement current { get; protected set; } = null;
        public GameObject checker;
        #endregion

        #region PUBLIC METHODS
        public void Initialize(params string[]texts) {
            var min = Mathf.Min(texts.Length, options.Length);

            for (int i = 0; i < min; ++i)
            {
                InitializeButtonText(i, texts);
                InitializeOptionButton(i);
            }
            HideUnusedOptions(min);
        }
        public void Restart() {
            DeselectAll();
            selected = false;
            current = null;
            SelectedIndex = -1;
            if (checker != null) { 
                checker.SetActive(false);
            }
        }
        public void Initialize() {
            for (int i = 0; i < options.Length; ++i)
            {
                InitializeOptionButton(i);
            }
        }
        public void Select(int index) {
            index = Mathf.Clamp(index,0, options.Length);
            options[index].Select();
        }
        #endregion

        #region PRIVATE METHODS
        private void DeselectAll() {
            for (int i = 0; i < options.Length; ++i)
                options[i].Deselect();
        }

        private void InitializeButtonText(int index, string[] texts) {
            var button = (OptionButton)options[index]; 

            if (texts == null)
                button.SetText("Sample..." + index);
            else
                button.SetText(texts[index]);
        }
        private void HideUnusedOptions(int start)
        {
            for (int i = start; i < options.Length; ++i)
                options[i].Hide();
        }
        private void InitializeOptionButton(int i) {
            var button = (OptionButton)options[i];

            int index = i;
            options[i].OnSelect = () =>
            {
                SelectedIndex = index;
                DeselectAll();
                button.SetColor(Selection, SelectedText);
                button.SetBackground(SelectionBkg);
                current = options[index];
                selected = true;
                if (checker != null) { 
                    checker.SetActive(true);
                    checker.transform.position = button.transform.position;
                }
            };
            options[i].OnDeselect = () =>
            {
                button.SetColor(Normal, NormalText);
                button.SetBackground(NormalBkg);
            };
        }
        #endregion
    }
}