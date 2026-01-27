using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();
    public Vector3 GetRandomPoint()
    {
        var randomIndex = Random.Range( 0, points.Count);
        return points[randomIndex].gameObject.transform.position;
    }
}
