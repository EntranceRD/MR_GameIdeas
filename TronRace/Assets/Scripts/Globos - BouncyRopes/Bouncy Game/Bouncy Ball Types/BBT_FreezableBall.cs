using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBT_FreezableBall : MonoBehaviour
{
    void OnMouseDown() {
        if (!freeze) { ClickAction(physics);return; }

        active = !active;
        HandleFreezeBehaviour();
    }
    private void Awake()
    {
        freezable = ball.GetComponent<IFreezable>();
        physics = ball.GetComponent<IPhysicsObject>();
    }

    public GameObject ball;
    public bool freeze = true;
    //[SerializeField] protected System.Action<IPhysicsObject> OnActivation;
    private IPhysicsObject physics;
    private IFreezable freezable;
    protected bool active = true;

    protected virtual void ClickAction(IPhysicsObject physics) { }

    private void HandleFreezeBehaviour() {
        if (!active)
        {
            freezable.Freeze();
        }
        else
        {
            freezable.Unfreeze();
            ClickAction(physics);
            //OnActivation?.Invoke(physics);
        }
    }
}
