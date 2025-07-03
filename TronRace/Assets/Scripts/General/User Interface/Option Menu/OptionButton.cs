using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance 
{
    [System.Serializable]
    public class OptionButton:OptionElement
    {
        #region CONSTRUCTORS
        public OptionButton()
        {
            
        }
        #endregion

        #region VARIABLES
        public ColorChanger background;
        public TMPro.TMP_Text label;
        #endregion

        #region PUBLIC METHODS
        public void SetText(string text)
        {
            label.text = text;
        }
        public void SetColor(Color bkg, Color txt) {
            background.ChangeColor(bkg);
            label.color = txt;
        }
        public void SetBackground(Sprite bkg) {
            background.image.sprite = bkg;
        }
        public bool CompareText(string text) { return label.text == text; }
        #endregion
    }
}