using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBT_FixedForce : BBT_FreezableBall
{

    public Vector3 impulse;

    protected override void ClickAction(IPhysicsObject physics)
    {
        physics.SetVelocity(impulse);
    }
}
