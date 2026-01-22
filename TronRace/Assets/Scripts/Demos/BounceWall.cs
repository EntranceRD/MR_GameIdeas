using Entrance;
using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
{
    //public Transform spawnPoint;
    //public Transform newWall;

    public bool invertY = false;
    public bool invertx = false;

    //public void Teleport(Transform spawnPoint, Transform newWall, BounceBall ball)
    //{

    //    ball.SetOrientation(newWall);
    //    ball.RecalculateDirection();
    //    ball.transform.position = new Vector3(spawnPoint.position.x, ball.transform.position.y, spawnPoint.position.z);
    //    ball.RecalculateVelocity();
    //}

    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BounceBall>();
        if(ball == null ) return;

        var angle = ball.angle;

        if (invertx) { 
            angle = 180f - angle;
        }
        if (invertY) {
            angle = 360f - angle;
        }
        ball.angle = angle;
        ball.RecalculateDirection();
        ball.RecalculateVelocity(invertY);
        //Teleport(spawnPoint, newWall, ball);
        
    }
}
