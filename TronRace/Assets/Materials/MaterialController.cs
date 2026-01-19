using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class MaterialController : MonoBehaviour, IRestartable
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            transition.Restart();
            //Restart();
            //ChangeColor(1);
        }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.2f);
            transition.Restart();
        }

        private void Update()
        {
            transition.Update(Time.deltaTime);
            if (transition.transitioning)
                changer.ChangeColor(transition.color);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private ColorChanger changer;
        [Space]
        [SerializeField] private ColorTransition transition;
        #endregion

        #region PUBLIC METHODS
        public void SetRendererState(bool state) { 
            changer.SetRendererState(state); 
        }
        public void SetColors(Color[] colors) {
            changer.SetColors(colors);
        }
        public void ChangeColor(int index)
        {
            changer.ChangeColor(index);
        }
        public void ChangeColor(Color color) {
            changer.ChangeColor(color);
        }
        public void SetTexture(Texture2D tex) {
            changer.SetTexture(tex); 
        }
        public void SetSprite(Sprite sprite)
        {
            changer.SetSprite(sprite);
        }
        public void Restart() {
            transition.Restart();
            changer.ChangeColor(transition.color);
        }
        public void StartTransition() {
            transition.Lerp();
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}