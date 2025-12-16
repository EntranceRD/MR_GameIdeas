using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ColorSequenceManager sequenceManager;

    void Start()
    {
        sequenceManager.StartGame();
    }
}
