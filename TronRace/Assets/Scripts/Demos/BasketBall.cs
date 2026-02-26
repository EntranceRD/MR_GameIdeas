using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entrance.Games.Demos;
using Entrance.Games;
using Entrance;

public class BasketBall : MonoBehaviour
{
    public ScoreController scoreManager;
    public ButtonEvent OnScore;


    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BounceBall>();
        if (ball == null) return;
        ball.Restart();
        OnScore.Call();
        scoreManager.AddPoints(1);
    }
}
