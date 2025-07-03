using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash 
{
    public class SquashUI_PlayerData : MonoBehaviour
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
        [SerializeField] private Color[] colors;
        [SerializeField] private TMPro.TMP_Text usernameDisplay;
        [SerializeField] private GameObject[] restingElements;
        [SerializeField] private GameObject[] playingElements;
        #endregion

        #region PUBLIC METHODS
        public void Initialize(string username) {
            usernameDisplay.text = username;
        }
        public void Rest()
        {
            SetElements(false);
            usernameDisplay.color = colors[0];
        }
        public void Play() {
            SetElements(true);
            usernameDisplay.color = colors[1];
        }
        public void Hide() { gameObject.SetActive(false); }
        public void Show() { gameObject.SetActive(true); }
        #endregion

        #region PRIVATE METHODS
        private void SetElements(bool playing)
        {
            foreach (var element in restingElements)
                element.SetActive(!playing);
            foreach (var element in playingElements)
                element.SetActive(playing);
        }
        #endregion
    }
}