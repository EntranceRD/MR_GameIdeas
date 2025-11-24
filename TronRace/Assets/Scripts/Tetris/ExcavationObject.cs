using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ExcavationObject : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            segments.SimpleIteration((segment) => {
                segment.OnFree.AddAction(() => {
                    Debug.Log(isFree());

                });
            });
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.F)) {
            //    Debug.Log(isFree());
            //}
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ObjectGroup<ExcavationObjectSegment> segments;
        #endregion

        #region PUBLIC METHODS
        public bool isFree()
        {
            var free = true;
            segments.SimpleIteration((segment) => {
                if (!segment.isFree) { free = false; }
            });
            return free;
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}