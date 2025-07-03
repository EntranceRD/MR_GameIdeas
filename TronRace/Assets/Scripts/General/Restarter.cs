using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Restarter : MonoBehaviour, IRestartable
    {
        #region VARIABLES
        [SerializeField]
        private GameObject[] objects;
        #endregion

        #region PUBLIC METHODS
        public void RestartObjects()
        {
            foreach (var obj in objects) {
                RestartObjectComponents(obj);
            }
        }
        public void Restart() {
            RestartObjects();
        }
        #endregion

        #region PRIVATE METHODS
        private void RestartObjectComponents(GameObject go)
        {
            var components = go.GetComponents<IRestartable>();
            foreach (var component in components)
                component.Restart();
        }
        #endregion
    }
}