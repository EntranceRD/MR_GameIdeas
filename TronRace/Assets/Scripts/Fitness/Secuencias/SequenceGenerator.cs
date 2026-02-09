using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Entrance.Games
{
    public class SequenceGenerator
    {
        public SequenceGenerator(AddToSequenceCondition condition)
        {
            mySequence = new List<int>();
            AddNumberCondition = condition;
        }

        public List<int> mySequence { get; protected set; }
        public delegate bool AddToSequenceCondition(int number);
        public AddToSequenceCondition AddNumberCondition;

        public List<int> CreateNewSequence(int minOptionValue, int maxOptionValue, int lenght)
        {
            var sequence = new List<int>();
            for (int i = 0; i < lenght; ++i)
            {
                var random = Random.Range(minOptionValue, maxOptionValue);
                sequence.Add(random);
            }
            return sequence;
        }
        public void ClearSequence() { mySequence.Clear(); }
        public void CreateSequence(int minOptionValue, int maxOptionValue, int lenght)
        {
            for (int i = mySequence.Count; i < lenght; ++i)
            {
                var newNumber = GetValidRandomNumberForSequence(minOptionValue, maxOptionValue);
                if (newNumber < 0)
                {
                    newNumber = GetNewNumberForSequence(minOptionValue, maxOptionValue);
                }
                mySequence.Add(newNumber);
            }
        }

        private int GetValidRandomNumberForSequence(int min, int max)
        {
            for (int i = 0; i < 20; i++)
            {
                var random = Random.Range(min, max);
                if (AddNumberCondition.Invoke(random))
                {
                    return random;
                }
            }
            return -1;
        }
        private int GetNewNumberForSequence(int min, int max)
        {
            for (int i = min; i < max; i++)
            {
                if (AddNumberCondition.Invoke(i))
                {
                    return i;
                }
            }
            return Random.Range(min, max);
        }
    }
}