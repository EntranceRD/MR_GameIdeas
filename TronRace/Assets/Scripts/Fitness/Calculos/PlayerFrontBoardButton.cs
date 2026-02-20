using UnityEngine;
using UnityEngine.UI;

namespace Entrance.Games.Mathematics
{
    public class PlayerFrontBoardButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private MathBoardManager gameManagerBoard;
        [SerializeField] private MiddleButton middleButton;
        //[SerializeField] private GameObject btn1, btn2;
        [SerializeField] private Renderer buttonRenderer;

        public void Restart()
        {
            buttonRenderer.material.color = Color.black;
            middleButton.gameObject.SetActive(false);
            //btn1.SetActive(true);
            //btn2.SetActive(false);
        }

        public void VerifyCorrectPlayer()
        {
            if (!gameManagerBoard.CheckCorrectPlayersPosition())
            {
                buttonRenderer.material.color = Color.red;
                return;
            }

            buttonRenderer.material.color = Color.green;
            gameManagerBoard.OptionsButtonsCoverState(false);
            //btn1.SetActive(false);
            //btn2.SetActive(true);
        }

        public void EnableMidButton()
        {
            buttonRenderer.material.color = Color.black;
            middleButton.gameObject.SetActive(true);
        }
    }
}