using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class InvisibleObject : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            try
            {
                var rend = GetComponent<Renderer>();
                rend.enabled = !MarkInvisible;
            }
            catch (System.Exception) { }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private bool MarkInvisible = true;
        #endregion
    }
}