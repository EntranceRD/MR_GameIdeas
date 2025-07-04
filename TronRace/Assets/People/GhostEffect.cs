using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class GhostEffect : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            if (ghostShader == null) return;

            foreach (var renderer in GetComponentsInChildren<Renderer>())
            {
                foreach (var mat in renderer.materials)
                {
                    mat.shader = ghostShader;
                    mat.color = color; // bluish-transparent
                }
            }
        }

        private void Update()
        {
            foreach (var renderer in GetComponentsInChildren<Renderer>())
            {
                foreach (var mat in renderer.materials)
                {
                    mat.shader = ghostShader;
                    mat.color = color; // bluish-transparent
                }
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField]private Shader ghostShader;
        [SerializeField] private Color color = new Color(0.5f, 0.5f, 1f, 0.3f);
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}