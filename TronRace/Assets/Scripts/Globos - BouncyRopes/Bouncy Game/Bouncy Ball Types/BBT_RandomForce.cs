using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBT_RandomForce : BBT_FreezableBall
{
    public float minForce = 1f;
    public float maxForce = 5f;
    protected override void ClickAction(IPhysicsObject physics)
    {
        var x = Random.Range(-1f, 1f);
        var y = Random.Range(-1f, 1f);
        var force = Random.Range(minForce, maxForce);
        var velocity = new Vector3(x, y, 0) * force;
        physics.SetVelocity(velocity);
    }
}
