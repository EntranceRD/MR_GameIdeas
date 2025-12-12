using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Entrance 
{
    public class BalloonInstantiator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            instanceTimer.OnFinish = () =>
            {
                InstantiateBalloon();
                //instanceTimer.Target = Random.Range(1, 5);
                instanceTimer.Restart();
            };
            
            instanceTimer.Restart();
        }

        private void Update() 
        {
            instanceTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        public bool recording = true;
        public bool replaying = false;
        [SerializeField] private Timer instanceTimer;
        [SerializeField]
        private ObjectInstantiator ballonInstantiator;
        [SerializeField] private ObjectGroup<Transform> instancePoints;
        [SerializeField] private Color[] colors;
        [SerializeField] private bool lockX, lockY, lockZ;
        [SerializeField] private List<int> instanceIndex = new List<int>();
        [SerializeField] private List<int> colorsIndex = new List<int>();
        [SerializeField] private List<float> intantiatedSizes = new List<float>();
        [SerializeField] private List<float> intantiatedDrag = new List<float>();
        private int replayIndex = 0;
        #endregion

        #region PUBLIC METHODS
        public void Method()
        {
            
        }
        #endregion

        #region PRIVATE METHODS
        private void InstantiateBalloon()
        {
            var rand = Random.Range(0, instancePoints.objects.Count);
            var randCol = Random.Range(0, colors.Length); ;
            //var randSize = Random.Range(0.8f, 1.6f);
            var randDrag = Random.Range(0.2f, 0.6f);
            var point = instancePoints.GetObject(rand);
            var balloon = ballonInstantiator.Instantiate(point);

            InitializeCoin(balloon, randCol, randDrag);

            /*if (replaying) {
                rand = instanceIndex[replayIndex];
                randCol = colorsIndex[replayIndex];
                replayIndex = (replayIndex + 1) % instanceIndex.Count;
                randSize = intantiatedSizes[replayIndex];
                randDrag = intantiatedDrag[replayIndex];
            }
            
            if (recording) { 
                instanceIndex.Add(rand);
                colorsIndex.Add(randCol);
                intantiatedSizes.Add(randSize);
                intantiatedDrag.Add(randDrag);
            }*/
        }

        private void InitializeCoin(Transform balloonObj, int colorIndex, float drag)
        {
            var balloon = balloonObj.GetComponent<Balloon>();

            balloon.SetMovementConstraints(lockX, lockY, lockZ);
            balloon.SetColor(colors[colorIndex]);
            balloon.SetDrag(drag);
            balloon.Heal(10);

            balloon.value = GameDifficulty.Instance.NewCoinValue();
            balloon.UpdateValueTxt();

            var size = GetSizeAccordingCoinValue(balloon.value);
            balloonObj.localScale = Vector3.one * 0.3f * size;
        }


        private float GetSizeAccordingCoinValue(int coinValue)
        {
            switch (coinValue)
            {
                case 1: return 0.5f;
                case 2: return .7f;
                case 5: return 1f;
                case 10: return 1.3f;
                default: return 1f;
            }
        }
        #endregion
    }
}