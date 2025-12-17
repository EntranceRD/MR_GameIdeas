using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region VARIABLES
    public ColorSequenceManager sequenceManager;
    #endregion

    #region PUBLIC METHODS
    void Start()
    {
        StartCoroutine(sequenceManager.StartGame());
    }
    #endregion
}
