using Entrance.Games.Mathematics;
using Entrance.Unity;
using System.Collections;
using UnityEngine;

public class MiddleButton : MonoBehaviour
{
    public Timer releasedTimer;
    public GameManager_MathBoard gameManager;
    [SerializeField] public bool playerReleased = false;
    [SerializeField] private bool timerFinish = false;

    void Start()
    {
        releasedTimer.OnFinish += CheckClickedButtons;
        releasedTimer.Restart();
    }

    void Update()
    {
        if (playerReleased)
        {
            releasedTimer.Tick(Time.deltaTime);
        } 
    }

    private void FixedUpdate()
    {
        if (timerFinish)
        {
            CheckClickedButtons();
        }
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        playerReleased = false;
        timerFinish = false;
        releasedTimer.Restart();
    }

    public void PlayerReleased()
    {
        playerReleased = true;
    }

    private void CheckClickedButtons()
    { 
        timerFinish = true;
        releasedTimer.Restart();
        if (gameManager.CheckAllPlayersInButtons())
        {
            gameManager.NewRound();
            gameObject.SetActive(false);
        }
    }
}
