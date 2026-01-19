using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Entrance.Games.Mathematics
{
    public class VerifyButton : MonoBehaviour
    {
        public GameManager_MathBoard gameManagerBoard;
        [SerializeField] private Image testImage;
        [SerializeField]private GameObject btn1, btn2;

        void Start()
        {

        }

        void Update()
        {

        }

        public void Restart()
        {
            testImage.color = Color.white;
            btn1.SetActive(true);
            btn2.SetActive(false);
        }

        public void VerifyCorrectPlayer()
        {
            if (!gameManagerBoard.CheckCorrectPlayersPosition())
            {
                testImage.color = Color.red;
                return;
            }
            testImage.color = Color.green;
            gameManagerBoard.UnlockOptionButtons();
            btn1.SetActive(false);
            btn2.SetActive(true);
        }

        public void OnEnable()
        {
            testImage.color = Color.white;
        }
    }
}