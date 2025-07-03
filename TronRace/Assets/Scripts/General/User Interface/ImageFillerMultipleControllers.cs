using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance 
{
    public class ImageFillerMultipleControllers : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            fillers = new List<IImageFiller>();
            foreach (var controller in fillControllers)
            {
                var filler = controller.GetComponent<IImageFiller>();
                if (filler != null)
                    fillers.Add(filler);
            }
        }

        private void LateUpdate()
        {
            if (fillers.Count <= 0) return;

            float max = 0f;
            foreach (var filler in fillers)
            {
                var amount = filler.amount;
                if (inverseFillers) amount = 1 - amount;
                if (amount > max) max = amount;
            }

            foreach (var img in images)
                img.fillAmount = Mathf.Clamp01(max*factor);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private GameObject[] fillControllers;
        private List<IImageFiller> fillers;
        [SerializeField]
        private Image[] images;

        [SerializeField] private bool inverseFillers = false;
        [Range(1, 5)] public float factor = 1f;
        #endregion
    }
}