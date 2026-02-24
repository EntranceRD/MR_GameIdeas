using Entrance.Games.Demos;
using UnityEngine;
public enum TeleportType
{
    Floor,
    Front,
    Back,
    Left,
    Right
}

public class TestTeleportCollider : MonoBehaviour
{
    public Transform spawnPoint;
    public TeleportType teleportType;
    //public List<Transform> newNextPoints = new List<Transform>();

    public void Teleport(Transform spawnPoint, MovibleElement movibleElement)
    {
        switch (teleportType)
        {
            case TeleportType.Floor:
                movibleElement.transform.position = new Vector3(movibleElement.transform.position.x, spawnPoint.position.y, movibleElement.transform.position.z);
                break;
            case TeleportType.Front:
                movibleElement.transform.position = new Vector3(spawnPoint.position.x, movibleElement.transform.position.y, movibleElement.transform.position.z);
                break;
            case TeleportType.Back:
                movibleElement.transform.position = new Vector3(spawnPoint.position.x, movibleElement.transform.position.y, movibleElement.transform.position.z);
                break;
            case TeleportType.Left:
                movibleElement.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.position.y, movibleElement.transform.position.z);
                break;
            case TeleportType.Right:
                movibleElement.transform.position = new Vector3(movibleElement.transform.position.x, spawnPoint.position.y, movibleElement.transform.position.z);
                break;
            default:
                break;
        }
        //movibleElement.SetNewTargetList(newNextPoints);
        //movibleElement.OnTargetReached?.Invoke();
    }

    //public void SearchSameSpawnPoint(MovibleElement movibleElement)
    //{
    //    //var previousPointIndex = movibleElement.targetPosIndex;
    //    for (int i = 0; i < spawnPoint.Length; i++)
    //    {
    //        if (i != previousPointIndex) continue;
    //        Teleport(spawnPoint[i], movibleElement);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision");
        var movibleElement = other.gameObject.GetComponent<MovibleElement>();
        if (movibleElement == null) return;
        //SearchSameSpawnPoint(movibleElement);
        Teleport(spawnPoint, movibleElement);
    }
}
