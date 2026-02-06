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
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartGame(amountOfPLayers);
            }
        }
        #endregion

        #region VARIABLES
        public static GameManager Instance;
        public ColorSequence colorSequence;
        public ScoreManager scoreManager;
        [SerializeField, Range(2, 5)] private int amountOfPLayers;
        [SerializeField] private ColorBoard[] colorBoards;
        #endregion

        #region PUBLIC METHODS
        void Start()
        {

        }

        public void StartGame(int amountOfPLayers)
        {
            Restart();
            var sequence = colorSequence.CreateNewColorSequence(amountOfPLayers);
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].InitializeBoard(sequence);
                colorBoards[i].boardDisplayer.StartSequence(sequence);
            }
        }

        public void Restart()
        {
            colorSequence.Restart();      
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].Restart();
            }
        }

        public void BoardGuessRightSequence(ColorBoard board)
        {
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].CleanBoard();
            }
            var sequence = colorSequence.GrowSequenceBy(1);
            for (int i = 0; i < colorBoards.Length; i++)
            {
                colorBoards[i].InitializeBoard(sequence);
                colorBoards[i].boardDisplayer.StartSequence(sequence);
            }
        }
        #endregion
    }
}