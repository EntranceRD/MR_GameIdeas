using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Mathematics
{
    public class GameManager_MathBoard : MonoBehaviour
    {
        public Operation operation;
        public VerifyButton verifyButton;
        public MiddleButton middleButton;
        public Collider optionsButtonsCoverage;
        public ScoreManager scoreManager;
        [SerializeField] private List<SimpleButton> playerPositionButtons = new List<SimpleButton>();
        [SerializeField] private List<SimpleButton> playerPositionButtonsActive = new List<SimpleButton>();
        private int currentPlayer = 0;

        public void Restart()
        {
            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(false);
            }
            SetActivePlayer(0);
            scoreManager.Restart();
            operation.CreateNewOperation();
            verifyButton.Restart();
            middleButton.Restart();
            LockOptionButtons();
        }

        private void Start()
        {
            Restart();
        }

        public void InitializePlayers(int totalPlayers)
        {
            playerPositionButtonsActive.Clear();
            for (int i = 0; i < totalPlayers; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(true);
                playerPositionButtonsActive.Add(playerPositionButtons[i]);
            }
        }

        public void MoveActivePlayerByValue(int offset)
        {
            currentPlayer = (currentPlayer + offset) % playerPositionButtonsActive.Count;
        }

        public void SetActivePlayer(int index)
        {
            index = Mathf.Clamp(index, 0, playerPositionButtonsActive.Count);
            currentPlayer = index;
        }

        public bool CheckCorrectPlayersPosition()
        {
            if (currentPlayer < 0)
            {
                return false;
            }

            if (playerPositionButtonsActive[currentPlayer].clicked)
            {
                return false;
            }

            for (int i = 0; i < playerPositionButtonsActive.Count; i++)
            {

                if (i != currentPlayer && !playerPositionButtonsActive[i].clicked)
                {
                    return false;
                }
            }
            return true;
        }

        public void NewRound()
        { 
            MoveActivePlayerByValue(1);
            operation.CreateNewOperation();
            Debug.Log("Nueva operacion creada y jugador: " + currentPlayer);
        }

        public bool CheckAllPlayersInButtons()
        {
            for (int i = 0; i < playerPositionButtonsActive.Count; i++)
            {
                if (!playerPositionButtonsActive[i].clicked)
                {
                    return false;
                }
            }
            return true;
        }

        public void LockOptionButtons()
        {
            optionsButtonsCoverage.enabled = true;
        }

        public void UnlockOptionButtons()
        {
            optionsButtonsCoverage.enabled = false;
        }
    }
}