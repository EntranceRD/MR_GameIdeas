using Entrance.Instantiation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PortalSetup : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            if (portalInstantiator == null) { portalInstantiator = GetComponent<Instantiator>(); }
            if (portal == null) { portal = GetComponent<SurfacePortal>(); }
            if (portalInstantiator == null || portal == null) return;

            portalInstantiator.OnObjectInstantiate += (obj) =>
            {
                obj.GetComponent<CustomLink>().Setup(portal);
            };
                portalInstantiator.InstantiateObjects();
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Instantiator portalInstantiator;
        [SerializeField]private SurfacePortal portal;
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