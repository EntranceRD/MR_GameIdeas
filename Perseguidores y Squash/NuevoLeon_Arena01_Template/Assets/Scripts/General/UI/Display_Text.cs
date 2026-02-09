using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.UI
{
    public class Display_Text : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField]private GameObject panel;
        [SerializeField]private TMPro.TMP_Text dataDisplay;
        #endregion

        #region PUBLIC METHODS
        public void Hide()
        {
            panel.SetActive(false);
        }
        public void Show() {
            panel.SetActive(true);
        }
        public void SetData(string text, int cap=-1) {
            if (cap > 0) {
                text = text.Substring(0, Mathf.Min(cap, text.Length));
            }
            dataDisplay.text = text;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}