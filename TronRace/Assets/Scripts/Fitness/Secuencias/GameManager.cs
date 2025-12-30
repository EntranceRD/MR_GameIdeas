using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region VARIABLES
    public ColorSequenceManager colorSequenceManager;
    [SerializeField, Range(2,10)] private int amountOfPLayers;
    #endregion

    #region PUBLIC METHODS
    void Start()
    {
        StartCoroutine(colorSequenceManager.StartGame(amountOfPLayers));
    }
    #endregion
}
