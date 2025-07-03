using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Topo : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            life.OnDie = () => {
                anim.SetAlive(life.isAlive());
                OnDespawn?.Invoke();
                StartCoroutine(RecycleAfterSeconds(2f));
            };
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private LifeObject life;
        [SerializeField] private Topo_AnimController anim;
        [SerializeField] private PoolableObject pool;
        public TopoHole hole;
        public System.Action OnDespawn;
        #endregion

        #region PUBLIC METHODS
        public void Restart() {
            life.Heal(1);
            anim.SetAlive(true);
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator RecycleAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            pool.Recycle();
            if (hole != null) { 
                hole.free = false;
            }
        }


        #endregion
    }
}