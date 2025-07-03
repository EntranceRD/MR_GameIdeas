using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Proxy_OptionsSelector : MonoBehaviour
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
        public bool selected => selector.selected;
        public int SelectedIndex => selector.SelectedIndex;
        [SerializeField] private OptionsSelector selector;
        #endregion

        #region PUBLIC METHODS
        public void Initialize()
        {
            selector.Initialize();
        }
        public void Initialize(params string[] texts) {
            selector.Initialize(texts);
        }
        public void Restart() {
            selector.Restart();
        }
        public void SelectOption(int index) {
            selector.options[index].Select();
        }
        public void SelectOption(string text) {
            var btns = selector.options;

            foreach (var btn in btns)
            {
                var sbtn = (OptionButton)btn;
                if (sbtn.CompareText(text))
                {
                    sbtn.Select();
                    return;
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}