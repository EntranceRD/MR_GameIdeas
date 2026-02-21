using System.Collections.Generic;
using Entrance.Games.Mathematics;
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
        [Header("References")]
        [SerializeField] private OptionButton[] possibleResultsBtns;
        private MathOperation operationController;

        [Header("Settings")]
        [SerializeField] private DifficultyLevels difficulty;
        public int correctResultIndex = -1;
        public List<int> results;
        public List<int> operands;
        public List<int> operators;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            correctResultIndex = -1;
            results.Clear();
        }

        public void CreateNewOperation()
        {
            if (operationController == null)
            {
                operationController = new MathOperation();
            }
            var totalOperations = GetTotalOperationsForDifficulty();
            operationController.PrepareNewOperation(totalOperations);
            operands = operationController.Operands;
            operators = operationController.Operators;
            results = CalculatePossibleResults(operationController.Result, possibleResultsBtns.Length - 1);
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

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i] == correctResult)
                {
                    correctResultIndex = i;
                    break;
                }
            }
            return results;
        }
        private int GetTotalOperationsForDifficulty()
        {
            switch (difficulty)
            {
                case DifficultyLevels.EASY: return 1;
                case DifficultyLevels.MEDIUM: return 2;
                case DifficultyLevels.HARD: return 3;
                default: return 1;
            }
        }
        #endregion
    }
}