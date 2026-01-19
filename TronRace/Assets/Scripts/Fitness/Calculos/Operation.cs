using System.Collections.Generic;
using System.Reflection;
using UnityEditorInternal;
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
        private void Awake()
        {
            for (int i = 0; i < possibleResultsBtns.Length; i++)
            {
                int idx = i;
                possibleResultsBtns[i].OnClick += ()=>{
                    VerifyAnswer(possibleResultsBtns[idx]);
                };
            }
        }
        #region VARIABLES
        public TMPro.TMP_Text operationText;
        public GameManager_MathBoard gameManagerBoard;
        public ScoreManager scoreManager;
        public int correctResultIndex = -1;
        [SerializeField] private DifficultyLevels difficulty;
        [SerializeField] private OptionButton[] possibleResultsBtns;
        private MathOperation operationController;
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
            var results = CalculatePossibleResults(operationController.Result, possibleResultsBtns.Length - 1);

            DisplayOperation();
            DisplayPossibleResults(results);
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

        private void VerifyAnswer(OptionButton btn)
        {
            if (correctResultIndex != btn.contextIndex)
            {
                btn.ChangeColor(Color.red);
                return;
            }

            var pointsForSolvedOperation = operationController.Operators.Count;
            scoreManager.AddPoints(pointsForSolvedOperation);
            btn.ChangeColor(Color.green);
            gameManagerBoard.middleButton.gameObject.SetActive(true);
            gameManagerBoard.LockOptionButtons();
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

        private void DisplayPossibleResults(List<int> results)
        {
            for (int i = 0; i < possibleResultsBtns.Length; i++)
            {
                possibleResultsBtns[i].Initialize(i, results[i].ToString());
            }
        }

        private void DisplayOperation()
        {
            operationText.text = $"{operationController.Operands[0]}";
            for (int i = 0; i < operationController.Operators.Count; i++)
            {
                operationText.text += $" {MathOperation.operatorsSymbols[operationController.Operators[i]]} {operationController.Operands[i + 1]}";
            }
        }
        #endregion
    }
}