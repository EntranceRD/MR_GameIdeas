using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Instantiation
{
    public class Instantiator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.I)) { InstantiateObjects(); }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private GameObject prefab;
        [SerializeField] private InstantiationSequence method;
        [SerializeField] private Transform instancePoint;
        [SerializeField] public float offset = 1.0f;
        [SerializeField] public int total = 1;
        public System.Action<GameObject> OnObjectInstantiate;
        #endregion

        #region PUBLIC METHODS
        public void InstantiateObjects()
        {
            var instancePosition = GetStartPosition();
            for (int i = 0; i < total; i++)
            {
                var obj = Instantiate(prefab, instancePoint);
                obj.transform.localPosition = instancePosition;
                instancePosition.y += offset;
                OnObjectInstantiate(obj);
            }
        }
        #endregion

        #region PRIVATE METHODS
        private Vector3 GetStartPosition()
        {
            var pos = Vector3.zero;
            switch (method) {
                case InstantiationSequence.LINE:break;
                //case InstantiationSequence.WAVE: pos.y = -((offset + (offset * total)) / 2f);break;
                case InstantiationSequence.WAVE: pos.y = -((offset * total) / 2f);break;
                default:break;
            }
            return pos;
        }
        #endregion
    }
}