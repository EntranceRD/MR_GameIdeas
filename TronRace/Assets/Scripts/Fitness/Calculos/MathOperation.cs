using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Mathematics
{
    internal class MathOperation
    {
        #region CONSTRUCTORS
        public MathOperation()
        {
            Operands = new List<int>();
            Operators = new List<int>();
        }
        #endregion

        #region VARIABLES
        public List<int> Operators;
        public List<int> Operands;
        public readonly static string[] operatorsSymbols = new string[] { "+", "-" };
        public int Result { get; private set; } = 0;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            Operators.Clear();
            Operands.Clear();
            Result = 0;
        }
        public void PrepareNewOperation(int totalOperations)
        {
            Operators.Clear();
            Operands.Clear();
            for (int i = 0; i < totalOperations; i++)
            {
                Operators.Add(GetRandomOperator());
            }
            Operands = GetRandomNumbers();

        }
        #endregion

        #region PRIVATE METHODS
        private int GetRandomOperator()
        {
            return Random.Range(0, operatorsSymbols.Length);
        }
        private List<int> GetRandomNumbers()
        {
            List<int> numbers = new List<int>();
            Result = Random.Range(5, 10);
            numbers.Add(Result);
            for (int i = 0; i < Operators.Count; i++)
            {
                var rand = Random.Range(1, 10);
                if (Operators[i] == 1)
                {
                    rand = Mathf.Min(Mathf.Max(numbers[i]-3,1), rand);
                    Result -= rand;
                }
                else
                {
                    Result += rand;
                }
                numbers.Add(rand);
            }
            return numbers;
        }
        #endregion
    }
}