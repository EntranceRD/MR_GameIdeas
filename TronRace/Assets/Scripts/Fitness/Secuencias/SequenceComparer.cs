using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Sequence 
{
    public enum SequenceComparisonResult
    {
        Incomplete,
        Incorrect,
        Correct
    }
    public class SequenceComparer
    {

        #region VARIABLES
        public System.Action<SequenceComparisonResult> OnSequenceCompareResult;
        #endregion

        #region PUBLIC METHODS
        public void CompareSequence(List<int> userSequence, List<int> correctSequence)
        {
            var result = AnalyzeSequence(userSequence, correctSequence);
            OnSequenceCompareResult(result);
        }
        #endregion

        #region PRIVATE METHODS
        private SequenceComparisonResult AnalyzeSequence(List<int> userSequence, List<int> correctSequence)
        {
            for (int i = 0; i < userSequence.Count; i++)
            {
                if (userSequence[i] != correctSequence[i])
                    return SequenceComparisonResult.Incorrect;
            }

            if (userSequence.Count < correctSequence.Count)
                return SequenceComparisonResult.Incomplete;

            return SequenceComparisonResult.Correct;
            
        }
        #endregion
    }
}