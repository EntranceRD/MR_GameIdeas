using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable2DPhysicObject : MonoBehaviour, IFreezable, IPhysicsObject
{
    #region VARIABLES
    [SerializeField] private Rigidbody2D physics;
    public PhysicMaterial2DObject physicsObj;
    //public float maxSpeed = 2f;
    #endregion

    #region PUBLIC METHODS
    public void Freeze() { SetPhysics(0f, RigidbodyConstraints2D.FreezeAll, true); }
    public void Unfreeze() { SetPhysics(0f, RigidbodyConstraints2D.None, false); }
    public void MakeDynamic() { physics.isKinematic = false; }
    public void MakeKinematic() { physics.isKinematic = true; }
    public void SetGravity(float gravity) { physics.gravityScale = gravity; }
    public void SetGravity(bool useGravity)
    {
        var gravity = useGravity ? 1f : 0f;
        SetGravity(gravity);
    }
    public void AddVelocity(Vector3 velocity) {
        var vel = physics.velocity + (Vector2)velocity;
        SetVelocity(vel);
    }
    public void SetVelocity(Vector3 velocity) {
        physicsObj.SetVelocity(velocity);
        //physicsObj.LimitVelocity();
        //var normal = velocity.normalized;
        //var speed = velocity.magnitude;
        //if (speed > maxSpeed) { speed = maxSpeed; }
        //physics.velocity = normal * speed; 
    }

    #endregion

    #region PRIVATE METHODS
    private void SetPhysics(float velocity, RigidbodyConstraints2D constraints, bool kinematic) {
        if (physics == null) return;

        physics.isKinematic = kinematic;
        physics.velocity = Vector2.one * velocity;
        physics.angularVelocity = 1f * velocity;
        physics.constraints = constraints;
    }
    #endregion
}
