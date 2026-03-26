using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Sequence
{
    public class ColorSequence : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            EnsureGenerator();
        }
        #endregion

        #region VARIABLES
        public ColorData[] colors;

        private int sequenceSize;
        private SequenceGenerator generator;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            EnsureGenerator();

            if (colors == null || colors.Length == 0)
            {
                Debug.LogError("Colors array is not assigned or empty", this);
                return;
            }

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] != null)
                    colors[i].used = false;
            }

            generator.ClearSequence();
        }

        public List<int> CreateNewColorSequence(int players)
        {
            EnsureGenerator();

            sequenceSize = players;
            generator.ClearSequence(); // importante para reiniciar correctamente
            generator.CreateSequence(0, colors.Length, players);

            Debug.Log("New Sequence: " + string.Join(",", generator.mySequence));
            return generator.mySequence;
        }

        public List<int> GrowSequenceBy(int amount)
        {
            EnsureGenerator();

            sequenceSize = generator.mySequence.Count + amount;
            generator.CreateSequence(0, colors.Length, sequenceSize);

            Debug.Log("Grow Sequence: " + string.Join(",", generator.mySequence));
            return generator.mySequence;
        }

        public Color[] GetDisplayColors()
        {
            EnsureGenerator();

            if (colors == null || generator.mySequence == null)
            {
                Debug.LogError("Colors or sequence not initialized", this);
                return null;
            }

            Color[] result = new Color[sequenceSize];

            for (int i = 0; i < sequenceSize; i++)
            {
                int colorIndex = generator.mySequence[i];

                if (colorIndex >= 0 && colorIndex < colors.Length && colors[colorIndex] != null)
                {
                    result[i] = colors[colorIndex].color;
                }
                else
                {
                    Debug.LogError($"Invalid color index: {colorIndex}", this);
                }
            }

            return result;
        }
        #endregion

        #region PRIVATE METHODS
        private void EnsureGenerator()
        {
            if (generator == null)
            {
                generator = new SequenceGenerator(AddNewNumberToSequenceCondition);
            }
        }

        private bool AddNewNumberToSequenceCondition(int newNumber)
        {
            return !generator.mySequence.Contains(newNumber);
        }
        #endregion
    }
}