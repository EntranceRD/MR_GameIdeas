using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class TopoButtonInstantiator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            topo.OnTopoDespawn = InstantiateRandomButton;
            for (int i = 0; i < initialButtons; i++)
            {
                InstantiateRandomButton();
            }
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.I)) {
            //    InstantiateRandomTopo();
            //}
        }
        #endregion

        #region VARIABLES
        [SerializeField,Range(1,20)] private int initialButtons = 15;
        public static TopoButtonInstantiator Instance;
        [SerializeField] private ObjectInstantiator instantiator;
        [SerializeField] private ObjectGroup<ButtonPosition> spawnPoints;
        [SerializeField] private Transform canvasParent;
        [SerializeField] private TopoInstantiator topo;
        #endregion

        #region PUBLIC METHODS
        public void InstantiateRandomButton()
        {
            //search random hole
            for (int i = 0; i < 20; i++)
            {
                var randPos = spawnPoints.GetRandomObject();
                if (randPos.free)
                {
                    var button = instantiator.Instantiate(randPos.transform);
                    button.GetComponent<TopoButton>().SetPosition(randPos);
                    button.transform.parent = canvasParent;
                    button.GetComponent<TopoButton>().OnClick = () => {
                        topo.InstantiateRandomTopo();
                    };
                    return;
                }
            }
            //look for available hole
            for (int i = 0; i < spawnPoints.objects.Count; i++)
            {
                var posiition = spawnPoints.GetObject(i);
                if (posiition.free) {
                    var button = instantiator.Instantiate(posiition.transform);
                    button.GetComponent<TopoButton>().SetPosition(posiition);
                    button.transform.parent = canvasParent;
                    button.GetComponent<TopoButton>().OnClick = () => {
                        topo.InstantiateRandomTopo();
                    };
                    return;
                }
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}