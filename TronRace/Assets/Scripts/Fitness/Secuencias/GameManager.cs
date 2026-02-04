using UnityEngine;

namespace Entrance.Games.Sequence
{

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

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                Restart();
            }
        }
        #endregion

        #region VARIABLES
        public static GameManager Instance;
        public ColorSequenceManager colorSequenceManager;
        public ColorSequence colorSequence;
        public ScoreManager scoreManager;
        [SerializeField, Range(2, 5)] private int amountOfPLayers;
        [SerializeField] private ColorBoard[] colorBoards;
        #endregion

        #region PUBLIC METHODS
        void Start()
        {
            StartGame(amountOfPLayers);
        }

        public void StartGame(int amountOfPLayers)
        {
            Restart();
            StartCoroutine(colorSequenceManager.StartColorSequence(amountOfPLayers));
        }

        public void StopGame()
        {

        }

        public void Restart()
        {
            scoreManager.Restart();
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].Restart();
            }
            colorSequence.Restart();
            colorSequenceManager.Restart(amountOfPLayers);
        }
        #endregion
    }
}