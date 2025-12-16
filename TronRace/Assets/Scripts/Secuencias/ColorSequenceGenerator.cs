using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class ColorSequenceGenerator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
            //currentSequence = new List<int>();
            //Restart();
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Return)) {
            //    Restart();
            //}
        }
        #endregion

        #region VARIABLES
        [SerializeField,Range(4,9)] private int SequenceSize = 5;
        [SerializeField] private Color[] colors;
        [SerializeField] private ObjectGroup<UnityEngine.UI.Image> sequenceDisplay;
        private List<int>currentSequence;
        #endregion

        #region PUBLIC METHODS
        public Color GetColor(int index) {
            index = Mathf.Max(index, 0);
            index = Mathf.Min(index, colors.Length - 1);
            return colors[index];
        }
        public void Restart() {
            //if (currentSequence == null) currentSequence = new List<int>();
            sequenceDisplay.SimpleIteration((display) => { display.enabled = false; });
            currentSequence = CreateNewSequence(SequenceSize);
            DisplaySequence(currentSequence);
        }

        public List<int> GetCurrentSequence()
        {
            return currentSequence;
        }
        #endregion

        #region PRIVATE METHODS
        private List<int> CreateNewSequence(int total) {
            var sequence = new List<int>();
            total = Mathf.Min(total, sequenceDisplay.objects.Count);
            for (int i = 0; i < total; i++)
            {
                sequence.Add(GetRandomColorIndex());
            }
            return sequence;
        }
        private void DisplaySequence(List<int> sequence) {
            for (int i = 0; i < sequence.Count; i++)
            {
                var display = sequenceDisplay.GetObject(i);
                display.enabled = true;
                display.color = colors[sequence[i]];
            }
        }
        private int GetRandomColorIndex()
        {
            return Random.Range(0, colors.Length);
        }
        #endregion
    }
}