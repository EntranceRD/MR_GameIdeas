using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class EnvironmentLighting : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            DarkRoom();   
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Color darkMode;
        [SerializeField] private Color lightMode;
        [SerializeField] private Color []lights;
        #endregion

        #region PUBLIC METHODS
        public void LightRoom()
        {
            RenderSettings.ambientLight = lightMode;  
        }
        public void DarkRoom() { 
            RenderSettings.ambientLight = darkMode;  
        }
        public void SetLight(int index) { 
            RenderSettings.ambientLight = lights[index];  
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}