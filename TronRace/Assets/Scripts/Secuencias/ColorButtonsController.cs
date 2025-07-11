using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ColorButtonsController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Return)) {
            //    ChangeButtonsPositions();
            //}
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        [Tooltip("Pink & Purple go last")]
        private ObjectGroup<ColorButton> buttons;
        #endregion

        #region PUBLIC METHODS
        public void ChangeButtonsPositions()
        {
            buttons.SimpleIteration((btn) => {
                btn.FreeSpawn();
                btn.ChangePosition();
            });
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}