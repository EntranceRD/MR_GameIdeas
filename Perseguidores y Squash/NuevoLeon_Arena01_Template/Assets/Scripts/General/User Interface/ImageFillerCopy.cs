using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance 
{
    public class ImageFillerCopy : MonoBehaviour, IImageFiller
    {

        #region VARIABLES
        [SerializeField] private Image img;
        [SerializeField] private bool inverted = false;
        public float amount
        {
            get
            {
                if (inverted)
                {
                    return 1.0f - img.fillAmount;
                }
                return img.fillAmount;
            }
        }
        #endregion
    }
}