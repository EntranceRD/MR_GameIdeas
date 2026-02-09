using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance
{
    public class MaterialOffseter : MonoBehaviour, IRestartable
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            if (rend == null) rend = GetComponent<Renderer>();
        }
        private void Start()
        {
            property = new MaterialPropertyBlock();
            mainTex = Shader.PropertyToID("_MainTex_ST");
            mainTexVector.x = Tiling.x;
            mainTexVector.y = Tiling.y;
        }

        private void Update()
        {
            rend.GetPropertyBlock(property);
            mainTexVector.w +=Time.deltaTime*scrollSpeedX;
            mainTexVector.w %= 1;
            mainTexVector.z += Time.deltaTime * scrollSpeedY;
            mainTexVector.z %= 1;
            property.SetVector(mainTex, mainTexVector);
            rend.SetPropertyBlock(property);
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private Renderer rend;
        private MaterialPropertyBlock property;

        private int mainTex = 0;
        private Vector4 mainTexVector = new Vector4(1, 1, 0, 0);
        [SerializeField] private Vector2 Tiling = Vector2.one;
        [SerializeField,Range(0, 1)]
        private float scrollSpeedX = 0.5f;
        [SerializeField,Range(0, 1)]
        private float scrollSpeedY = 0.5f;
        #endregion

        public void Restart()
        {
            rend.GetPropertyBlock(property);
            mainTexVector.w = 0;
            property.SetVector(mainTex, mainTexVector);
            rend.SetPropertyBlock(property);
        }
    }
}