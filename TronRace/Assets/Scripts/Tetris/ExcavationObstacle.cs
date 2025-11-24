using Entrance.Interaction;
using Entrance.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ExcavationObstacle : MonoBehaviour, IInteractible
    {
        #region UNITY METHODS
        private void Start()
        {
            Restart();
            interactionTime.OnFinish = () => {
                _collider.enabled = false;
                var ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 5)) {
                    var exc_obj = hit.transform.GetComponent<ExcavationObjectSegment>();
                    if (exc_obj != null) {
                        exc_obj.SetFree();
                    }
                }
                //recycle to pool?
                //send raycast to excavationObjectSegment Free
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R)) {
                Restart();
            }
            if (!interacting) return;
            interactionTime.Tick(Time.deltaTime);
            //group.alpha = 1f - (interactionTime.Remaining / interactionTime.Target);
            group.alpha = (interactionTime.Remaining / interactionTime.Target);
            interacting = false;
        }
        #endregion

        #region VARIABLES
        public Action<Interaction.Touch> OnInteract { get; set; }
        [SerializeField] private Collider _collider;
        [SerializeField] private Timer interactionTime;
        [SerializeField] private CanvasGroup group;
        private bool interacting = false;
        #endregion

        #region PUBLIC METHODS
        public void Interact(Interaction.Touch touch)
        {
            interacting = true;
        }
        public void Restart() {
            _collider.enabled = true;
            group.alpha = 1;
            interactionTime.Restart();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }


        #endregion
    }
}