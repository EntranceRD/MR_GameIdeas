using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class SurfacePortal : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            //portalGenerator.InstantiateObjects();
            visuals.Initialize(portalGenerator.offset, portalGenerator.total);
        }

        private void Update()
        {

        }
        #endregion

        #region VARIABLES
        [Header("Portal Creation")]
        [SerializeField] private Instantiation.Instantiator portalGenerator;
        [SerializeField] private PortalSetup portalSetup;
        [Space]
        [Header("Portal Behaviour")]
        [SerializeField] public Transform newSurfaceNormals;
        [SerializeField] public MovementDirections exitDirection;
        [SerializeField] public bool changeDirection = false;
        [SerializeField] public bool InvertX = true;
        [Space]
        [SerializeField] private GeneratorVisual visuals;
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