using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
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
            var rand = Random.Range(0, instancePoints.objects.Count); ;
            var randCol = Random.Range(0, colors.Length); ;
            var randSize = Random.Range(0.8f, 1.6f);
            var randDrag = Random.Range(0.2f, 0.6f);
            if (replaying) {
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
            }

            var point = instancePoints.GetObject(rand);
            var balloon = ballonInstantiator.Instantiate(point);

            var _balloon = balloon.GetComponent<Balloon>();
            _balloon.SetMovementConstraints(lockX, lockY, lockZ);
            _balloon.SetColor(colors[randCol]);
            _balloon.SetDrag(randDrag);
            _balloon.Heal(10);

            Vector3 scale = Vector3.one * .3f * randSize;
            balloon.transform.localScale = scale;
        }
        #endregion
    }
}