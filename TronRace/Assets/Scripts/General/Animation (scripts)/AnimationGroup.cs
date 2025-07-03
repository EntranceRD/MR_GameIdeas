using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class AnimationGroup : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            pool = new ObjectPool();
            //for (int i = 0; i < animations.Count; i++)
            //{
            //    animations[i].OnActivation.AddAction()
            //}
            foreach (var anim in animations) { 
                pool.SetupObjectForPoolOnRecycle(anim);
                anim.Recycle();
            }
        }

        //private void Update()
        //{
            
        //}
        #endregion

        #region VARIABLES
        [SerializeField] private List<ParticleAnimationObject> animations;
        private ObjectPool pool;
        #endregion

        #region PUBLIC METHODS
        public void PlayNewAnimationOn(Transform pos)
        {
            var obj = pool.GetObject();
            if (obj == null) return;
            obj.transform.position = pos.position;
            obj.Activate();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}