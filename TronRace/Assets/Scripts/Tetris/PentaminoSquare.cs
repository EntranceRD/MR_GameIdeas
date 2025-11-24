using Entrance.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PentaminoSquare : MonoBehaviour, IInteractible
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
        private Pentamino mainFigure;

        public Action<Interaction.Touch> OnInteract { get; set; }
        #endregion

        #region PUBLIC METHODS
        public void Setup(Pentamino figure) {
            mainFigure = figure;
        }
        public void Interact(Interaction.Touch touch)
        {
            var pos = new Vector3(touch.position.x, touch.position.y, touch.position.z);
            mainFigure.SetPosition(pos);
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}