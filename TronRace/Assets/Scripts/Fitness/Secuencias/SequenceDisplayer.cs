using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Sequence
{
    public class SequenceDisplayer : MonoBehaviour
    {
        #region VARIABLES
        [Header("References")]
        [SerializeField] private Transform highlightableContainer;

        [Header("Settings")]
        [SerializeField, Range(0, 60f)] private float totalDisplayTime = 5f;
        [SerializeField, Range(0, 1f)] private float highlightPercentageTime = .7f;
        //[SerializeField, Range(0, 5f)] private float displayTime;
        //[SerializeField, Range(0, 5f)] private float timeBetweenDisplay;

        public bool displayingSequence { get; private set; } = false;
        public System.Action OnStartDisplaying;
        public System.Action OnFinishDisplaying;
        public System.Action<int, int> OnDisplayElement;

        private float awaithighlightPercentageTime = 0f;
        private List<int> mySequence = new List<int>();
        private IEnumerator displaySequenceInstruction;
        private IHighlightableObject[] highlightableObjects;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            Initialize();
        }

        public void DisplaySequence(List<int> sequence)
        {
            if (displayingSequence) { return; }
            mySequence = sequence;
            if (displaySequenceInstruction == null)
            {
                displaySequenceInstruction = displaySequence();
            }

            displaySequenceInstruction = displaySequence();

            StartCoroutine(displaySequenceInstruction);
        }

        public void ForceStop()
        {
            displayingSequence = false;
            StopCoroutine(displaySequenceInstruction);
        }

        #endregion

        #region PRIVATE METHODS
        private void Initialize()
        {
            highlightableObjects = highlightableContainer.GetComponentsInChildren<IHighlightableObject>();

            if (displaySequenceInstruction == null)
            {
                displaySequenceInstruction = displaySequence();
            }
            ForceStop();
        }

        private IEnumerator displaySequence()
        {
            displayingSequence = true;
            OnStartDisplaying?.Invoke();

            awaithighlightPercentageTime = 1f - highlightPercentageTime;
            var dispTime = (totalDisplayTime/ mySequence.Count) * highlightPercentageTime;
            var tbd = (totalDisplayTime / mySequence.Count) * awaithighlightPercentageTime;

            //var dispTime = displayTime - (0.025f * mySequence.Count);
            //var tbd = timeBetweenDisplay - (0.0125f * mySequence.Count);
            //var totalDisplayTime = dispTime + tbd;
            for (int i = 0; i < mySequence.Count; i++)
            {
                OnDisplayElement?.Invoke(mySequence[i], i);
                highlightableObjects[mySequence[i]].Highlight(dispTime);
                yield return new WaitForSeconds(dispTime+tbd);
            }
            displayingSequence = false;
            OnFinishDisplaying?.Invoke();
        }
        #endregion
    }
}