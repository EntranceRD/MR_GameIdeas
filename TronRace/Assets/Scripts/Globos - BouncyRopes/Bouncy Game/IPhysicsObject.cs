using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicsObject
{
    void AddVelocity(Vector3 velocity);
    void SetVelocity(Vector3 velocity);
    void MakeKinematic();
    void MakeDynamic();
    void SetGravity(bool useGravity);
    void SetGravity(float gravity);
}
