using Entrance.Games;
using UnityEngine;

namespace Entrance.Games.Squash
{
    public class SquashGameManager : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject); return;
            }
            Instance = this;
        }

        private void Start()
        {
            instructionsDisplayer.OnFinishDisplaying += () =>
            {
                gameTime.Resume();
                ReleaseBalls();
                squashMusic.Play();
                backgroundMusic.Stop();
            };
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartGame();
            }
        }
        #endregion

        #region VARIABLES
        public static SquashGameManager Instance;
        [Header("Settings")]
        [SerializeField, Range(2, 10)] private int amountOfPlayers;
        [SerializeField] private GenericTimerComponent gameTime;

        [Header("Instructions")]
        [SerializeField] private Entrance.Games.InstructionsDisplayer instructionsDisplayer;

        [Header("GameOver")]
        [SerializeField] private GameOverController gameOverController;

        [Header("Logic")]
        [SerializeField] private SquashBallGenerator squashBallGenerator;

        [Header("Rank")]
        [SerializeField] private TheRanking ranking;

        [Header("Audio")]
        [SerializeField] private AudioSource squashMusic;
        [SerializeField] private AudioSource backgroundMusic;

        [Header("Others")]
        [SerializeField] private GeneralAnimator[] animScores;
        #endregion

        #region PUBLIC METHODS
        public void StartGame()
        {
            Restart();
            instructionsDisplayer.Display();
        }

        public void EndGame()
        {
            squashBallGenerator.StopPlayers();
            ranking.ShowRanking(squashBallGenerator.GetPlayersScores());
            gameOverController.Display();
        }
        #endregion

        #region PRIVATE METHODS
        private void Restart()
        {
            squashMusic.Stop();
            gameTime.Restart();
            squashBallGenerator.Restart();
            instructionsDisplayer.Restart();
            ranking.Restart();
            backgroundMusic.Play();
            gameOverController.Restart();
            foreach (var anim in animScores)
            {
                anim.Restart();
            }
        }

        public void PreparePlayers()
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                squashBallGenerator.PreparePlayer(i);
            }
        }

        private void ReleaseBalls()
        {
            squashBallGenerator.ReleasePlayers();
        }
        #endregion
    }
}