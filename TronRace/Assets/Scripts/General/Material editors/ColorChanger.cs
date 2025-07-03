using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance 
{
    [Serializable]
    public class ColorChanger
    {
        #region CONSTRUCTORS
        public ColorChanger()
        {
            colors = new Color[2] { Color.white, Color.red };
        }
        #endregion

        #region VARIABLES
        public Image image;
        public MeshRenderer renderer;
        public Color[] colors;

        private MaterialPropertyBlock material;
        #endregion

        #region PUBLIC METHODS
        public void SetColors(Color[] colors)
        {
            this.colors = colors;
        }
        public void ChangeColor(Color col)
        {
            if (image != null)
                image.color = col;
            if (renderer != null) {
                PrepareMaterial();
                renderer.GetPropertyBlock(material);
                material.SetColor("_Color",col);
                renderer.SetPropertyBlock(material);
            }
        }
        public void ChangeColor(int index) {
            if (colors == null || colors.Length == 0) return;
            index = Mathf.Clamp(index, 0, colors.Length);
            ChangeColor(colors[index]);
        }
        public void SetSprite(Sprite sprite) {
            if (image == null) return;
            image.sprite = sprite;
        }
        public void SetTexture(Texture2D tex)
        {
            if (renderer == null) return;
            PrepareMaterial();
            renderer.GetPropertyBlock(material);
            material.SetTexture("_MainTex", tex);
            renderer.SetPropertyBlock(material);
        }
        #endregion

        #region PRIVATE METHODS
        private void PrepareMaterial()
        {
            if (material != null) return;
            material = new MaterialPropertyBlock();
        }
        #endregion
    }
}