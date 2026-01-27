using Entrance;
using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCollider : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform newWall;

    public void Teleport(Transform spawnPoint, Transform newWall, BounceBall ball)
    {
        ball.SetOrientation(newWall);
        ball.RecalculateDirection();
        ball.transform.position = new Vector3(spawnPoint.position.x, ball.transform.position.y, spawnPoint.position.z);
        ball.RecalculateVelocity(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BounceBall>();
        if(ball == null ) return;

        Teleport(spawnPoint, newWall, ball);  
    }
}
