using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePointer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { drawingLine = true; }
        if (Input.GetMouseButtonUp(0)) { drawingLine = false; }

        if (!drawingLine) return;

        var ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(ray.origin, ray.origin + (ray.direction * 10), Color.green);
        RaycastHit hit;
        //Physics2D.Raycast(ray.origin, ray.direction, out hit, 20f);
        if (Physics.Raycast(ray, out hit, 20f)) {
            //Debug.Log($"obj: {hit.transform.name}");

            var component = hit.transform.GetComponent<LineDrawer>();
            if (component != null)
            {
                //Debug.Log($"Raycast is hitting point {hit.point}");
                component.Draw(hit.point);
            }
        }
    }



    [Range(0, 10)] public int button = 0;
    private bool drawingLine=false;

    public Camera cam;
}
