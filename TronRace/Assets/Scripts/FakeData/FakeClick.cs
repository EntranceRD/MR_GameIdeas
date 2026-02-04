using Entrance.General;
using Entrance.Interaction;
using UnityEngine;

public class FakeClick : MonoBehaviour
{
    private bool sustained = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { clickForward(); }
        if (Input.GetKeyDown(KeyCode.X)) { sustained=!sustained; }
        if (sustained) { clickForward(); }
    }

    private void clickForward() {
        var pos = transform.position;
        var direction = transform.forward;
        Debug.DrawLine(pos, pos + (direction * 10), Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(pos, direction, out hit, 10))
        {
            CreatePointInteraction(hit);
        }
    }
    private void CreatePointInteraction(RaycastHit hit)
    {
        var pos = new Vec3(hit.point.x, hit.point.y, hit.point.z);
        var interactible = hit.collider.GetComponent<IInteractible>();
        if (interactible != null)
            interactible.Interact(new Entrance.Interaction.Touch(pos));
    }
}