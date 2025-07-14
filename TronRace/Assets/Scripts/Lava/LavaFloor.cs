using Entrance.Interaction;
using Entrance.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class LavaFloor : MonoBehaviour, IInteractible
    {
        #region UNITY METHODS
        private void Start()
        {
            scoreTime.Restart();
            scoreTime.OnFinish = () => {
                scoreTime.Restart();
                if (!isInteractingWithLava) {
                    score.AddScore();
                    //scoreDisplay.text = $"Score: {score}";
                }
                isInteractingWithLava = false;
            };
        }

        private void Update()
        {
            scoreTime.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Timer scoreTime;
        [SerializeField] private TMPro.TMP_Text scoreDisplay;
        [SerializeField]
        private Score score;
        private bool isInteractingWithLava = false;

        public Action<Interaction.Touch> OnInteract { get; set; }
        #endregion

        #region PUBLIC METHODS
        public void Interact(Interaction.Touch touch)
        {
            isInteractingWithLava = true;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }


        #endregion
    }
}