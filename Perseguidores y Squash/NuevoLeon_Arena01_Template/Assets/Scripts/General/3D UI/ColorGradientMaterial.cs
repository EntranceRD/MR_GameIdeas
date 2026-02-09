using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ColorGradientMaterial : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            var width = Mathf.CeilToInt(steps);
            var height = Mathf.CeilToInt(steps);

            var tex = new Texture2D(width, height);
            tex.alphaIsTransparency = true;
            float yStep = 1F / steps;

            for (int y = 0; y < height; y++)
            {
                Color col = color.Evaluate(y * yStep);

                for (int x = 0; x < width; x++)
                {
                    tex.SetPixel(x, y, col);
                }
            }
            tex.Apply();
            foreach (var obj in objects) {
                obj.SetTexture(tex);
            }
        }
        #endregion

        #region VARIABLES
        public int steps=50;
        public Gradient color;
        public MaterialController []objects;
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