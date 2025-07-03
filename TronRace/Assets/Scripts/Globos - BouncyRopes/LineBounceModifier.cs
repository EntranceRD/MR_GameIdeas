using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBounceModifier : MonoBehaviour
{
    private void Start()
    {
        drawer.OnLineSegmentSpawn = SetSurfaceBounciness;
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return)) {
        //    drawer.OnLineSegmentSpawn = SetSurfaceBounciness;
        //}
    }
    public int bounceIndex;
    public float[] bouncinesses;
    public Color[] bouncinessColors;
    public LineDrawer drawer;
    [SerializeField]
    private float bounciness = 0f;

    public void SetBounciness(int index) {
        bounceIndex = index;
        bounciness = bouncinesses[index];
    }
    public void SetBounciness(float bounciness) {
        this.bounciness = bounciness;
    }

    private void SetSurfaceBounciness(GameObject collider) {
        var surface = collider.GetComponent<BouncySurface>();
        if (surface == null) return;
        //surface.bounciness = bouncinesses[bounceIndex];
        surface.bounciness = bounciness;
        collider.GetComponentInParent<LineRenderer>().startColor = bouncinessColors[bounceIndex];
        collider.GetComponentInParent<LineRenderer>().endColor = bouncinessColors[bounceIndex];
    }
}
