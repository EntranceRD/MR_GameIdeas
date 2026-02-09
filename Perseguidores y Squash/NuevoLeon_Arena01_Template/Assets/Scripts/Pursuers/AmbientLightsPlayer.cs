using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class AmbientLightsPlayer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            hue += Time.deltaTime * colorRatePerSecond;
            hue %= 1;
            SetColorForLights(Color.HSVToRGB(hue, 1, 1));
        }
        #endregion

        #region VARIABLES
        [SerializeField] private MaterialController[] lights;
        [SerializeField, Range(0,1)] private float colorRatePerSecond;
        private float hue = 0f;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void SetColorForLights(Color color)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].ChangeColor(color);
            }
        }
        #endregion
    }
}