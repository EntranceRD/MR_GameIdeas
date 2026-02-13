using Entrance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private List<Image> playerLaneMask = new List<Image>();
        [SerializeField] private List<Image> playerLaneMaskActive = new List<Image>();
        private int currentPlayer = 0;
        private int currentLane = 0;

        public void Restart()
        {
            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < playerLaneMask.Count; i++)
            {
                playerLaneMask[i].gameObject.SetActive(true);
            }
            SetActivePlayer(0);
            scoreManager.Restart();
            operation.CreateNewOperation();
            verifyButton.Restart();
            middleButton.Restart();
            LockOptionButtons();
            LaneMask();
        }

        private void Start()
        {
            Restart();
        }

        public void InitializePlayers(int totalPlayers)
        {
            LaneMask();
            playerPositionButtonsActive.Clear();
            playerLaneMaskActive.Clear();
            for (int i = 0; i < totalPlayers; i++)
            {
                playerPositionButtons[i].gameObject.SetActive(true);
                playerPositionButtonsActive.Add(playerPositionButtons[i]);
                //playerLaneMask[i].gameObject.SetActive(false);
                //playerLaneMaskActive.Add(playerLaneMask[i]);
            }
        }

        public void MoveActivePlayerByValue(int offset)
        {
            currentPlayer = (currentPlayer + offset) % playerPositionButtonsActive.Count;
            currentLane = (currentLane + offset) % playerLaneMask.Count;
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
            LaneMask();
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

        private void LaneMask()
        {
            for (int i = 0; i < playerLaneMask.Count; i++)
            {
                if (i == currentPlayer)
                {
                    playerLaneMask[i].gameObject.SetActive(false);
                    playerLaneMaskActive.Add(playerLaneMask[i]);
                    continue;
                }
                playerLaneMask[i].gameObject.SetActive(true);
                playerLaneMaskActive.Add(playerLaneMask[i]);

            }
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