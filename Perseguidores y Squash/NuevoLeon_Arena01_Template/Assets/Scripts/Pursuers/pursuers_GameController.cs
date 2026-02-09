using Entrance;
using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Pursuers 
{
    public class pursuers_GameController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Initialize();
            //Restart();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P)) { pursuersController.DeactivateAll(); difficultyController.Pause(); scoreController.Pause(); }
            if (Input.GetKeyDown(KeyCode.O)) { /*pursuersController.DeactivateAll();*/ difficultyController.Resume(); scoreController.Resume(); }
            if (Input.GetKeyDown(KeyCode.R)) { Restart(); }
        }
        #endregion

        #region VARIABLES
        [SerializeField] private PursuersController pursuersController;
        [SerializeField] private PursuerDifficulty difficultyController;
        [SerializeField] private PursuersScore scoreController;
        #endregion

        #region PUBLIC METHODS
        public void Restart() {
            pursuersController.Restart();
            difficultyController.Restart();
            scoreController.Restart();
            //pursuersController.Activate(4);
        }
        #endregion

        #region PRIVATE METHODS
        private void Initialize()
        {
            pursuersController.Initialize();
            difficultyController.Initialize();
            scoreController.Initialize();
            scoreController.Pause();
        }
        #endregion
    }
}