using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    #region UNITY METHODS
    private void Awake()
    {
    }
    #endregion

    #region VARIABLES
    [Range(0, 3)]
    public float bounciness = .4f;

    public Entrance.EdgeCollider3D Collider3D;
    private Vector3 right;
    #endregion

    #region PUBLIC METHODS
    public void SetRigidColliderRight(Vector3 right) {
        this.right = right;
    }
    public void Activate() {
        Collider3D.Activate();
    }
    public void SetupBounciness() { 
        Collider3D.SetBounciness(bounciness);
    }
    public void Deactivate() {
        Collider3D.Deactivate();
    }

    public void Setup(Vector3[] points, float size, Vector3 position) {
        if (points.Length < 2) {
            Deactivate();
            return;
        }

        Collider3D.SetPoints(points, right);
    }
    #endregion
}
