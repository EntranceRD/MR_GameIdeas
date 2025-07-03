using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash 
{
    public class PhantomFollower : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
     
        }

        private void Update()
        {
            if (!Alive) return;
            lifeTime.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        public bool Alive = false;
        private Timer lifeTime;
        #endregion

        #region PUBLIC METHODS
        public void Spawn(Vector3 position, float lifetime)
        {
            Initialize();
            gameObject.SetActive(true);
            Alive = true;
            transform.position = position;
            lifeTime.Target = lifetime;
            lifeTime.Restart();
        }
        public void Despawn() {
            Alive = false;
            gameObject.SetActive(false);
        }
        public void SetVisibility(bool visibility) {
            var renderer = GetComponent<Renderer>();
            if (renderer != null) { renderer.enabled = visibility; }
        }
        #endregion

        #region PRIVATE METHODS
        private void Initialize()
        {
            if (lifeTime == null) {
                lifeTime = new Timer();
                lifeTime.OnFinish = () => {
                    Alive = false;
                    gameObject.SetActive(false);
                };
            }
        }
        #endregion
    }
}