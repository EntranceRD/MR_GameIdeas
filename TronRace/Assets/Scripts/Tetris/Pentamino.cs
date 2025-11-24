using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Pentamino : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            squares.SimpleIteration((square) => {
                square.Setup(this);
            });
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ObjectGroup<PentaminoSquare> squares;
        [SerializeField] private ExcavationObject excavationObject;
        [SerializeField] private bool lockX = false;
        [SerializeField] private bool lockY = false;
        [SerializeField] private bool lockZ = false;
        #endregion

        #region PUBLIC METHODS
        public void SetPosition(Vector3 pos)
        {
            if (!excavationObject.isFree()) return;
            Debug.Log($"New position of pentomino: {pos}");
            transform.position = GetLockedPosition(pos);
        }
        #endregion

        #region PRIVATE METHODS
        private Vector3 GetLockedPosition(Vector3 newPos)
        {
            var pos = Vector3.zero;
            pos.x = lockX ? transform.position.x : newPos.x;
            pos.y = lockY ? transform.position.y : newPos.y;
            pos.z = lockZ ? transform.position.z : newPos.z;
            return pos;
        }
        #endregion
    }
}