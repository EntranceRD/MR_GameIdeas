using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class TransformAssist : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            trans = GetComponent<Transform>();
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        private Transform trans;
        #endregion

        #region PUBLIC METHODS
        public void Reposition(Vector3 pos)
        {
            Reposition(pos, Quaternion.identity);
        }
        public void Reposition(Vector3 pos, Quaternion rot)
        {
            if (trans == null) return;
            trans.position = pos;
            trans.rotation = rot;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}