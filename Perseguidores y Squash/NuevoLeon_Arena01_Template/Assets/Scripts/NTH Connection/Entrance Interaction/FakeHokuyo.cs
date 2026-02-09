using Entrance.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class FakeHokuyo : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(InteractionKey))
            {
                var points = new Vector3[transform.childCount];
                for (int i = 0; i < points.Length; i++)
                {
                    points[i] = transform.GetChild(i).position;
                }
                input.CheckInteractions(transform.up * -1, points);
            }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private KeyCode InteractionKey;
        public EI_InputController input;
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