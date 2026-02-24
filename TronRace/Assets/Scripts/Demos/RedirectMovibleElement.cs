using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class RedirectMovibleElement : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }


        private void OnTriggerEnter(Collider other)
        {
            var movibleElement = other.gameObject.GetComponent<MovibleElement>();
            if (movibleElement == null) return;
            movibleElement.SetNewTargetList(newTargetList);
            movibleElement.OnTargetReached?.Invoke();
        }
        #endregion

        #region VARIABLES
        public List<Transform> newTargetList = new List<Transform>();
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