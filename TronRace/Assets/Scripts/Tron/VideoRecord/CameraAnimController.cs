using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class CameraAnimController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) { SetAnimIndex(200); }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Animator anim;
        #endregion

        #region PUBLIC METHODS
        public void SetAnimIndex(int index)
        {
            anim.SetInteger("AnimIdx", index);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}