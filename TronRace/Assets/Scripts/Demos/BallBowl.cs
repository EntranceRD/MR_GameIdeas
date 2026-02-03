using UnityEngine;
public class BallBowl : MonoBehaviour
{

    public float speedRotationZ;
    public Vector3 initialPos;
    public Vector3 initialRotation;

    private void Awake()
    {
        initialPos = transform.position;
        initialRotation = transform.eulerAngles;
    }

    public void Restart()
    {
        transform.position = initialPos;
        transform.eulerAngles = initialRotation;
    }

    private void Update()
    {
        var rotation = transform.eulerAngles;
        rotation.z += speedRotationZ * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}