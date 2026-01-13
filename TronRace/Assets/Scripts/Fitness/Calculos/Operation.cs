using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Mathematics
{
    public enum DifficultyLevels
    {
        EASY = 1,
        MEDIUM,
        HARD
    }
    
    public class Operation : MonoBehaviour
    {
        #region VARIABLES
        public TMPro.TMP_Text operationText;
        public TMPro.TMP_Text[] possibleResults;
        private MathOperation operationController;
        [SerializeField] private DifficultyLevels difficulty;
        #endregion

        #region PUBLIC METHODS
        //public void SetDifficulty(DifficultyLevels level) { difficulty = level; }
        public void CreateNewOperation()
        {
            if (operationController == null)
            {
                operationController = new MathOperation();
            }
            var totalOperations = GetTotalOperationsForDifficulty();
            operationController.PrepareNewOperation(totalOperations);

            //display operation
            operationText.text = $"{operationController.Operands[0]}";
            for (int i = 0; i < operationController.Operators.Count; i++)
            {
                operationText.text += $" {MathOperation.operatorsSymbols[operationController.Operators[i]]} {operationController.Operands[i + 1]}";
            }

            //display possible results
            var results = CalculatePossibleResults(operationController.Result, possibleResults.Length - 1);
            for (int i = 0; i < possibleResults.Length; i++)
            {
                possibleResults[i].text = results[i].ToString();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private List<int> CalculatePossibleResults(int correctResult, int extraResults)
        {
            var results = new List<int>();
            results.Add(correctResult);

            for (int i = 0; i < extraResults; i++)
            {
                var difference = Random.Range(-10, 10);
                if (difference == 0) difference = -30;
                results.Add(correctResult + difference);
            }
            results.Shuffle();
            return results;
        }
        private int GetTotalOperationsForDifficulty() {
            switch (difficulty)
            {
                case DifficultyLevels.EASY: return 1;
                case DifficultyLevels.MEDIUM: return 2;
                case DifficultyLevels.HARD: return 3;
                default:return 1;
            }
        }
        #endregion
    }
}