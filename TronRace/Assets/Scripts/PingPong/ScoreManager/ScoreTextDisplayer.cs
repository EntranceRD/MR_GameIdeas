using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ScoreTextDisplayer : MonoBehaviour
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
        [SerializeField] private TMPro.TMP_Text[] displays;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            UpdateDisplayWithValue(0);
        }
        public void UpdateDisplayWithValue(int value)
        {
            for (int i = 0; i < displays.Length; i++)
            {
                if (displays[i] != null) { 
                    displays[i].text = value.ToString("00");
                }
            }
        }
        #endregion

        #region PRIVATE METHODS

        #endregion
    }
}