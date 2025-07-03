using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance 
{
    public class ImageFillerByTime : ValueDisplay
    {
        #region UNITY METHODS
        private void LateUpdate()
        {
            foreach (var img in images)
                if(img!=null)
                img.fillAmount = amount;
        }
        #endregion

        #region VARIABLES
        [SerializeField]
        private Image[]images;
        public float amount { get; private set; } = 0f;
        #endregion

        public override void Restart()
        {
            amount = 1f;
        }
        public override void SetValue(float value) {
            amount = Mathf.Clamp01(value);
        }
    }
}