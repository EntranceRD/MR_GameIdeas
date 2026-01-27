using Entrance.Games.Demos;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirectionMod : Mod
{
    public float maxRandomAngle = 90f;
    public float impulse;

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.GetComponent<BounceBall>();
        if(obj != null )
        obj.angle = Random.Range(0,maxRandomAngle);
        obj.RecalculateDirection();
        obj.Impulse(impulse);
        RecycleMod();
    }
}
