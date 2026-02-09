using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance
{
    public class ImageMaterialOffseter : MonoBehaviour, IRestartable
    {
        #region UNITY METHODS
        private void Start()
        {
            mainTex = Shader.PropertyToID("_MainTex_ST");
        }

        private void Update()
        { 
            if(mat==null)return;
            mainTexVector.w +=Time.deltaTime*scrollSpeed;
            mainTexVector.w %= 1;
            mat.SetVector(mainTex, mainTexVector);
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private Material mat;

        private int mainTex = 0;
        private Vector4 mainTexVector = new Vector4(1, 1, 0, 0);
        [SerializeField,Range(0, 1)]
        private float scrollSpeed = 0.5f;
        #endregion

        public void Restart()
        {
            mainTexVector.w = 0;
            mat.SetVector(mainTex, mainTexVector);
        }
    }
}