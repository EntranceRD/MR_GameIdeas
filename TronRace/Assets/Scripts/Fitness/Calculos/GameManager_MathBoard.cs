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
        [SerializeField] private List<SimpleButton> playerPositionButtons = new List<SimpleButton>();
        private int currentPlayer = 0;

        public void Restart()
        {
            SetActivePlayer(0);
            operation.CreateNewOperation();
            verifyButton.Restart();
            middleButton.Restart();
            LockOptionButtons();
        }

        public void MoveActivePlayerByValue(int offset)
        {
            currentPlayer = (currentPlayer + offset) % playerPositionButtons.Count;
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

            if (playerPositionButtons[currentPlayer].clicked) //Jugador en turno no salio de la base
            {
                return false;
            }

            for (int i = 0; i < playerPositionButtons.Count; i++)
            {

                if (i != currentPlayer && !playerPositionButtons[i].clicked) //El jugador {i} abandono su posicion
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
            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                if (!playerPositionButtons[i].clicked)
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
            //optionsButtonsCoverage.SetActive(false);
        }
    }
}