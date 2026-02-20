using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance.Games.Mathematics
{
    public class MathBoardManager : MonoBehaviour
    {
        public void Start()
        {
            operationVerifier.OnOperationVerified += () =>
            {
                OptionsButtonsCoverState(true);
                scoreManager.AddPoints(operationVerifier.pointsForSolvedOperation);
                operationDisplayer.Celebrate();
                playerFrontBoardButton.EnableMidButton();
                //NewRound();
            };
        }

        [Header("References")]
        [SerializeField] private Operation operation;
        [SerializeField] private OperationDisplayer operationDisplayer;
        [SerializeField] private OperationVerifier operationVerifier;
        [SerializeField] private PlayerFrontBoardButton playerFrontBoardButton;
        [SerializeField] private Collider optionsButtonsCoverage;
        [SerializeField] private ScoreManager scoreManager;
        private int currentPlayer = 0;
        private int currentLane = 0;
        [SerializeField] private List<SimpleButton> playerPositionButtons = new List<SimpleButton>();

        //[Header("PlayersButtons")]
        //[SerializeField] private List<SimpleButton> playerPositionButtonsActive = new List<SimpleButton>();

        //[Header("Mask")]
        //[SerializeField] private List<Image> playerLaneMask = new List<Image>();
        //[SerializeField] private List<Image> playerLaneMaskActive = new List<Image>();

        //[SerializeField] private VerifyButton verifyButton;
        //public MiddleButton middleButton;

        public void Restart()
        {
            //for (int i = 0; i < playerPositionButtons.Count; i++)
            //{
            //    playerPositionButtons[i].gameObject.SetActive(false);
            //}
            //for (int i = 0; i < playerLaneMask.Count; i++)
            //{
            //    playerLaneMask[i].gameObject.SetActive(true);
            //}
            OptionsButtonsCoverState(true);
            SetActivePlayer(0);
            scoreManager.Restart();
            operation.Restart();
            operationDisplayer.Restart();
            operationVerifier.Restart();
            playerFrontBoardButton.Restart();
            //operation.CreateNewOperation();
            //verifyButton.Restart();
            //middleButton.Restart();
            //LaneMask();
            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(false);

            }
        }
        
        public void InitializeGame(int totalPlayers)
        {
            InitializePlayersPositions(totalPlayers);
            NewOperation();
        }

        private void NewOperation()
        {
            operation.CreateNewOperation();
            operationDisplayer.Display(operation.results, operation.operands, operation.operators);
            operationVerifier.correctResultIndex = operation.correctResultIndex;
            operationVerifier.pointsForSolvedOperation = operation.operators.Count;
        }

        private void InitializePlayersPositions(int totalPlayers)
        {
            //LaneMask();
            //playerPositionButtonsActive.Clear();
            //playerPositionButtons.Clear();
            //playerLaneMaskActive.Clear();
            for (int i = 0; i < totalPlayers; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(true);
                //playerPositionButtonsActive.Add(playerPositionButtons[i]);
                //playerLaneMask[i].gameObject.SetActive(false);
                //playerLaneMaskActive.Add(playerLaneMask[i]);
            }
        }

        public void MoveActivePlayerByValue(int offset)
        {
            currentPlayer = (currentPlayer + offset) % playerPositionButtons.Count;
            //currentLane = (currentLane + offset) % playerLaneMask.Count;
        }

        public void SetActivePlayer(int index)
        {
            index = Mathf.Clamp(index, 0, playerPositionButtons.Count);
            currentPlayer = index;
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
            MoveActivePlayerByValue(1);
            NewOperation();
            //LaneMask();
            //for (int i = 0; i < playerLaneMask.Count; i++)
            //{
            //    if(i==currentPlayer)
            //    {
            //        playerLaneMask[i].gameObject.SetActive(false);
            //        playerLaneMaskActive.Add(playerLaneMask[i]);
            //        continue;
            //    }
            //    playerLaneMask[i].gameObject.SetActive(true);
            //    playerLaneMaskActive.Add(playerLaneMask[i]);
            //}
            Debug.Log("Nueva operacion creada y jugador: " + currentPlayer);
        }

        //private void LaneMask()
        //{
        //    for (int i = 0; i < playerLaneMask.Count; i++)
        //    {
        //        if (i == currentPlayer)
        //        {
        //            //playerLaneMask[i].gameObject.SetActive(false);
        //            //playerLaneMaskActive.Add(playerLaneMask[i]);
        //            playerLaneMask[i].gameObject.transform.localScale = new Vector3(0, 1, 1);
        //            continue;
        //        }
        //        playerLaneMask[i].gameObject.transform.localScale = new Vector3(1, 1, 1);
        //        //playerLaneMask[i].gameObject.SetActive(true);
        //        //playerLaneMaskActive.Add(playerLaneMask[i]);

        //    }
        //}

        public bool CheckAllPlayersInButtons()
        {
            Debug.Log("Checking if all players are in buttons...");
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
    }
}