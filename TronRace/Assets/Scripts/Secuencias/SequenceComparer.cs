using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entrance.Games;

namespace Entrance 
{
    public class SequenceComparer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            sequenceGenerator.Restart();
            ClearSequence();
            PrepareSequence(sequenceGenerator.GetCurrentSequence());
            buttonsController.ChangeButtonsPositions();
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public ScoreController scoreManager;
        [SerializeField] private ColorSequenceGenerator sequenceGenerator;
        [SerializeField] private ColorButtonsController buttonsController;
        [SerializeField] private ObjectGroup<UnityEngine.UI.Image> sequenceDisplay;
        private int colorToCompare = 0;
        #endregion

        #region PUBLIC METHODS
        public void CompareSequenceWith(ColorButton button)
        {
            var sequence = sequenceGenerator.GetCurrentSequence();
            if (button.SequenceValue == sequence[colorToCompare]) {
                //display color
                sequenceDisplay.GetObject(colorToCompare).color = sequenceGenerator.GetColor(button.SequenceValue);

                colorToCompare++;
                if (colorToCompare >= sequence.Count) {
                    scoreManager.AddPoints(sequence.Count);
                    //ScoreManager.Instance.UpdateSequences(1);
                    colorToCompare = 0;
                    ClearSequence();
                    sequenceGenerator.Restart();
                    var seq = sequenceGenerator.GetCurrentSequence();
                    PrepareSequence(seq);
                    buttonsController.ChangeButtonsPositions();
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void PrepareSequence(List<int> sequence) {
            for (int i = 0; i < sequence.Count; i++)
            {
                sequenceDisplay.GetObject(i).enabled = true;
            }
        }
        private void ClearSequence()
        {
            sequenceDisplay.SimpleIteration((img) => {
                img.enabled = false;
                img.color = new Color(1, 1, 1, 0.3f);
            });
        }
        #endregion
    }
}