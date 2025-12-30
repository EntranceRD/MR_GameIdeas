using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); return;
        }
        Instance = this;
    }
    #endregion

    #region VARIABLES
    public static GameManager Instance;
    public ColorSequenceManager colorSequenceManager;
    public ColorSequence colorSequence;
    [SerializeField, Range(2,10)] private int amountOfPLayers;
    [SerializeField] private ColorBoard[] colorBoards;
    #endregion

    #region PUBLIC METHODS
    void Start()
    {
        StartGame(amountOfPLayers);
    }

    public void StartGame(int amountOfPLayers)
    {
        StartCoroutine(colorSequenceManager.StartColorSequence(amountOfPLayers));
    }

    public void StopGame()
    {

    }

    public void Restart()
    {
        colorSequence.Restart();
        colorSequenceManager.Restart();
        for (int i = 0; i < colorBoards.Length; i++)
        {
            colorBoards[i].Restart();
        }
    }
    #endregion
}
