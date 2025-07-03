using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class DotsAnimator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            animTimer = new Timer()
            {
                Target = Random.Range(2, 10),
                OnFinish = PlayDotsAnimation
            };
            animTimer.Restart();
        }

        private void Update()
        {
            animTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        private Timer animTimer;
        [SerializeField]
        private Animator anim;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void PlayDotsAnimation()
        {
            StartCoroutine(playDotsAnimation());    
        }
        private IEnumerator playDotsAnimation() {
            var rand = Random.Range(1, 5);
            anim.SetInteger("Anim", rand);
            yield return new WaitForSeconds(0.5f);
            anim.SetInteger("Anim", 0);
            animTimer.Target = Random.Range(8, 20);
            animTimer.Restart();
        }
        #endregion
    }
}