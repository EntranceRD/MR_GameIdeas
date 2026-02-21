using System.Collections.Generic;
using UnityEngine;
using Entrance.Games.Mathematics;

namespace Entrance.Games.Mathematics
{
    public class MathBoardManager : MonoBehaviour
    {
        #region UNITY METHODS
        public void Start()
        {
            operationVerifier.OnOperationVerified += () =>
            {
                OptionsButtonsCoverState(true);
                scoreManager.AddPoints(operationVerifier.pointsForSolvedOperation);
                operationDisplayer.Celebrate();
                floor.transform.localScale = new Vector3(-1, 1, 1);
                playerFrontBoardButton.EnableMidButton();
            };
        }
        #endregion

        #region VARIABLES
        [Header("References")]
        public ScoreManager scoreManager;
        [SerializeField] private List<GeneralAnimator> generalAnimators;
        [SerializeField] private GameObject floor;

        [Header("OperationReferences")]
        [SerializeField] private Operation operation;
        [SerializeField] private OperationDisplayer operationDisplayer;
        [SerializeField] private OperationVerifier operationVerifier;

        [Header("ButtonsReferences")]
        [SerializeField] private List<SimpleButton> playerPositionButtons = new List<SimpleButton>();
        [SerializeField] private PlayerFrontBoardButton playerFrontBoardButton;
        [SerializeField] private Collider optionsButtonsCoverage;

        private int currentPlayer = 0;
        private int currentLane = 0;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            scoreManager.Restart();
            operation.Restart();
            operationDisplayer.Restart();
            operationVerifier.Restart();
            playerFrontBoardButton.Restart();
            OptionsButtonsCoverState(true);
            SetActivePlayer(0);
            floor.transform.localScale = new Vector3(1, 1, 1);
            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < generalAnimators.Count; i++)
            {
                generalAnimators[i].SetAnimationStateValue(0);
            }
        }

        public void InitializeGame(int totalPlayers)
        {
            InitializePlayersPositions(totalPlayers);
            NewOperation();
            generalAnimators[currentPlayer].SetAnimationStateValue(1);
        }


        public bool CheckCorrectPlayersPosition()
        {
            if (currentPlayer < 0)
            {
                return false;
            }

            if (playerPositionButtons[currentPlayer].clicked)
            {
                return false;
            }

            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                if (!playerPositionButtons[i].isActiveAndEnabled) { continue; }

                if (i != currentPlayer && !playerPositionButtons[i].clicked)
                {
                    return false;
                }
            }
            return true;
        }

        public void NewRound()
        {
            generalAnimators[currentPlayer].SetAnimationStateValue(2);
            MoveActivePlayerByValue(1);
            NewOperation();
            generalAnimators[currentPlayer].SetAnimationStateValue(1);
            floor.transform.localScale = new Vector3(1, 1, 1);
        }

        public bool CheckAllPlayersInButtons()
        {
            //generalAnimators[currentPlayer].SetAnimationStateValue(2);
            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                if (!playerPositionButtons[i].isActiveAndEnabled) { continue; }

                if (!playerPositionButtons[i].clicked)
                {
                    return false;
                }
            }
            return true;
        }

        public void OptionsButtonsCoverState(bool state)
        {
            optionsButtonsCoverage.enabled = state;
        }
        #endregion

        #region PRIVATE METHODS
        private void NewOperation()
        {
            operation.CreateNewOperation();
            operationDisplayer.Display(operation.results, operation.operands, operation.operators);
            operationVerifier.correctResultIndex = operation.correctResultIndex;
            operationVerifier.pointsForSolvedOperation = operation.operators.Count;
        }

        private void InitializePlayersPositions(int totalPlayers)
        {
            for (int i = 0; i < totalPlayers; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(true);
            }
        }

        private void MoveActivePlayerByValue(int offset)
        {
            var buttonsActive = 0;
            foreach (var btn in playerPositionButtons)
            {
                if (btn.isActiveAndEnabled) { buttonsActive++; }
            }
            currentPlayer = (currentPlayer + offset) % buttonsActive;
        }

        private void SetActivePlayer(int index)
        {
            index = Mathf.Clamp(index, 0, playerPositionButtons.Count);
            currentPlayer = index;
        }
        #endregion
    }
}