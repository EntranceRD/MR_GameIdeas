using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash 
{
    public class ProxyPlayer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) players[0].Click(new Entrance.Interaction.Touch());
            if (Input.GetKeyDown(KeyCode.Alpha2)) players[1].Click(new Entrance.Interaction.Touch());
            if (Input.GetKeyDown(KeyCode.Alpha3)) players[2].Click(new Entrance.Interaction.Touch());
            if (Input.GetKeyDown(KeyCode.R)) gameController.Restart();
        }
        #endregion

        #region VARIABLES
        public SimpleButton[] players;
        public GameController gameController;
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