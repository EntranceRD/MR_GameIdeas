using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicMaterial2DObject : MonoBehaviour
{
    private void Awake()
    {
        physics = GetComponent<Rigidbody2D>();
        //mat = new PhysicsMaterial2D();
        //mat.friction = 0;
        //mat.bounciness = 1;
        //physics.sharedMaterial = mat;
    }
    private void FixedUpdate()
    {
        LimitVelocity();
    }

    private Rigidbody2D physics;
    [Range(0, 20), SerializeField] private float SpeedLimit=5;
    //private PhysicsMaterial2D mat;

    public void SetMaterial(PhysicsMaterial2D material) {
        //mat.bounciness = bounciness;
        physics.sharedMaterial = material;

    }
    public void SetVelocity(Vector3 velocity) {
        physics.velocity = velocity;
        LimitVelocity();
    }
    public void LimitVelocity() {
        var speed = physics.velocity.magnitude;
        if (speed > SpeedLimit)
        {
            var dir = physics.velocity.normalized;
            physics.velocity = dir * SpeedLimit;
        }
    }
}
