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
        [SerializeField] private List<SimpleButton> buttons = new List<SimpleButton>();
        private int currentPlayer = 0;

        public void Restart()
        {
            SetActivePlayer(0);
            operation.CreateNewOperation();
            verifyButton.Restart();
            middleButton.Restart();
        }

        public void MoveActivePlayerByValue(int offset)
        {
            currentPlayer = (currentPlayer + offset) % buttons.Count;
        }

        public void SetActivePlayer(int index)
        {
            index = Mathf.Clamp(index, 0, buttons.Count);
            currentPlayer = index;
        }

        public bool CheckCorrectPlayersPosition()
        {
            if (currentPlayer < 0)
            {
                return false;
            }

            if (buttons[currentPlayer].clicked) //Jugador en turno no salio de la base
            {
                return false;
            }

            for (int i = 0; i < buttons.Count; i++)
            {

                if (i != currentPlayer && !buttons[i].clicked) //El jugador {i} abandono su posicion
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
            for (int i = 0; i < buttons.Count; i++)
            {
                if (!buttons[i].clicked)
                {
                    return false;
                }
            }
            return true;
        }
    }
}