using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Topo_AnimController : MonoBehaviour
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
        [SerializeField] private Animator anim;
        #endregion

        #region PUBLIC METHODS
        public void SetAlive(bool state)
        {
            Debug.Log($"Alive {state}");
            anim.SetBool("isAlive", state);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}