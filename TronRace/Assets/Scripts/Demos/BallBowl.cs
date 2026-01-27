using Entrance.Games.Demos;
using UnityEngine;

public class BallBowl : MovibleElement
{
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BounceBall>();
        if (ball == null) return;

        scoreManager.AddPoints(1);
    }
}
