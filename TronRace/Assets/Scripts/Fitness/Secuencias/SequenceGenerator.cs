using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceGenerator
{
    public List<int> CreateSequence(int minOptionValue, int maxOptionValue, int lenght)
    {
        var sequence = new List<int>();
        for (int i = 0; i < lenght; ++i)
        {
            var random = Random.Range(minOptionValue, maxOptionValue);
            sequence.Add(random);
        }
        return sequence;
    }
}
