using Entrance;
using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntranceGames.Pursuers
{
    public class PursuersController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {

        }

        private void Update()
        {
            newTargetTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField] private FloorPursuer[] pursuers;
        [SerializeField] private ObjectGroup<Transform> StartingPositions;
        [SerializeField] private Timer newTargetTimer;
        [SerializeField] private PlayerLocator playerLocator;
        [SerializeField] private ButtonEvent onPlayerCapture;
        //[SerializeField] private AudioSource playerCaptureAudio;
        //[SerializeField] private Counter score;
        #endregion

        #region PUBLIC METHODS
        public void SetSpeedMultiplier(float multiplier) {
            for (int i = 0; i < pursuers.Length; i++) {
                pursuers[i].SetSpeedMultiplier(multiplier);
            }
        }
        public void Initialize() {
            newTargetTimer.OnFinish = () => {
                newTargetTimer.Restart();
                for (int i = 0; i < pursuers.Length; i++)
                {
                    //if (pursuers[i].pursuing)
                    //{
                        var target = playerLocator.FindClosestPointTo(pursuers[i].transform.position);
                        pursuers[i].SetTarget(target);
                    //}
                }
            };

            for (int i = 0; i < pursuers.Length; i++) {
                pursuers[i].Initialize();
                pursuers[i].OnPlayerCapture = OnPlayerCapture;
            }
        }
        public void Activate(int count) {
            int min = Mathf.Min(count, pursuers.Length);
            for (int i = 0; i < min; i++) {
                pursuers[i].Activate();
            }
        }
        public void Restart() {
            newTargetTimer.Restart();

            for (int i = 0; i < pursuers.Length; i++) {
                pursuers[i].Deactivate();
                pursuers[i].SetSpeedMultiplier(1f);
                pursuers[i].SetPosition(StartingPositions.GetObject(i).position);
            }
        }

        public void DeactivateAll()
        {
            for (int i = 0; i < pursuers.Length; i++)
            {
                pursuers[i].Deactivate();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void OnPlayerCapture() {
            onPlayerCapture.Call();
            //playerCaptureAudio.Stop();
            //playerCaptureAudio.Play();
        }
        //private void RestartPursuer(FloorPursuer pursuer)
        //{
  
        //}
        #endregion
    }
}