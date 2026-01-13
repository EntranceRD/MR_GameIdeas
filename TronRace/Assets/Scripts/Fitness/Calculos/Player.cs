using Entrance.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int rayDistance = 3;
    private Vector3 initialPos;
    private void Awake()
    {
        initialPos = transform.position;
    }
    void Start()
    {
        
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f))
        {
            var component = hit.transform.GetComponent<IInteractible>();
            if (component != null)
            {
                var pos = hit.transform.position;
                component.Interact(new Entrance.Interaction.Touch(new Entrance.General.Vec3(pos.x, pos.y, pos.z)));
            }
        }
    }

    public void Restart()
    {
        transform.position = initialPos;
    }
}
