using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance 
{
    public class ImageFiller : ValueDisplay
    {
        #region UNITY METHODS
        private void Start()
        {
            //filler = fillController.GetComponent<IImageFiller>();
        }

        //private void LateUpdate()
        //{
        //    if (filler == null) return;
        //    var amount = filler.amount;
        //    foreach (var img in images)
        //        img.fillAmount = amount;
        //}
        #endregion

        #region VARIABLES
        //[SerializeField] private GameObject fillController;
        //private IImageFiller filler;
        [SerializeField]
        private Image[]images;
        #endregion

        public override void Restart()
        {
            SetValue(1);
        }
        public override void SetValue(float amount) {
            amount = Mathf.Clamp01(amount);
            foreach (var img in images)
                img.fillAmount = amount;
        }
    }
}