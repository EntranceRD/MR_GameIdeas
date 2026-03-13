using Entrance.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Games.Coins
{
    public class BalloonInstantiator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            instanceTimer.OnFinish = () =>
            {
                instanceTimer.Restart();
                InstantiateBalloon();
                //instanceTimer.Target = Random.Range(1, 5);
            };
            //instanceTimer.Restart();

            for (int i = 0; i < instancePoints.objects.Count; i++)
            {
                surfacePoints.AddRange(instancePoints.GetObject(i).GetComponentsInChildren<Transform>());
            }
        }

        private void Update() 
        {
            if(instantiatorState == false) { return; }
            instanceTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES

        [SerializeField] private Timer instanceTimer;
        [SerializeField] private ObjectInstantiator balloonInstantiator;
        [SerializeField] private ObjectGroup<Transform> instancePoints;
        [SerializeField] private ObjectGroup<Transform> surfacePoints;
        [SerializeField] private Color[] colors;
        [SerializeField] private bool lockX, lockY, lockZ;
        public bool instantiatorState = false;
        //public bool recording = true;
        //public bool replaying = false;
        //[SerializeField] private List<int> instanceIndex = new List<int>();
        //[SerializeField] private List<int> colorsIndex = new List<int>();
        //[SerializeField] private List<float> intantiatedSizes = new List<float>();
        //[SerializeField] private List<float> intantiatedDrag = new List<float>();
        //private int replayIndex = 0;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            instantiatorState = false;
            balloonInstantiator.Restart();
            instanceTimer.Restart();
        }

        public List<PoolableObject> GetRemainingCoins()
        {
            return balloonInstantiator.GetCreatedObj();
        }
        #endregion

        #region PRIVATE METHODS
        private void InstantiateBalloon()
        {
            var rand = Random.Range(0, surfacePoints.objects.Count);
            var randCol = Random.Range(0, colors.Length); ;
            //var randSize = Random.Range(0.8f, 1.6f);
            var randDrag = Random.Range(0.2f, 0.6f);
            var point = surfacePoints.GetObject(rand);
            var balloon = balloonInstantiator.Instantiate(point);

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