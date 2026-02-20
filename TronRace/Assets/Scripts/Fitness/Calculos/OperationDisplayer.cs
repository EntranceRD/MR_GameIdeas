using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Mathematics
{
    public class OperationDisplayer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {

        }
        #endregion

        #region VARIABLES
        public TMPro.TMP_Text operationText;
        [SerializeField] private OptionButton[] possibleResultsBtns;
        //private MathOperation operationController;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            operationText.text = string.Empty;
            for (int i = 0; i < possibleResultsBtns.Length; i++)
            {
                possibleResultsBtns[i].Restart();
            }
        }

        public void Display(List<int> results, List<int> operands, List<int> operators)
        {
            DisplayOperation(operands, operators);
            DisplayPossibleResults(results);
        }

        public void Celebrate()
        {
            operationText.text = "¡Correcto!";
        }
        #endregion

        #region PRIVATE METHODS
        private void DisplayPossibleResults(List<int> results)
        {
            for (int i = 0; i < possibleResultsBtns.Length; i++)
            {
                possibleResultsBtns[i].Initialize(i, results[i].ToString());
            }
        }

        private void DisplayOperation(List<int> operands,List<int> operators)
        {
            operationText.text = $"{operands[0]}";
            for (int i = 0; i < operators.Count; i++)
            {
                operationText.text += $" {MathOperation.operatorsSymbols[operators[i]]} {operands[i + 1]}";
            }
            //operationText.text = $"{operationController.Operands[0]}";
            //for (int i = 0; i < operationController.Operators.Count; i++)
            //{
            //    operationText.text += $" {MathOperation.operatorsSymbols[operationController.Operators[i]]} {operationController.Operands[i + 1]}";
            //}
        }
        #endregion
    }
}