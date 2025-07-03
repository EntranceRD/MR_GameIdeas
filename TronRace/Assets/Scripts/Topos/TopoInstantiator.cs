using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class TopoInstantiator : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.I)) {
            //    InstantiateRandomTopo();
            //}
        }
        #endregion

        #region VARIABLES
        public static TopoInstantiator Instance;
        [SerializeField] private ObjectInstantiator instantiator;
        [SerializeField] private ObjectGroup<TopoHole> spawnPoints;
        [SerializeField] private Transform floorParent;
        public System.Action OnTopoDespawn;
        #endregion

        #region PUBLIC METHODS
        public void InstantiateRandomTopo()
        {
            //search random hole
            for (int i = 0; i < 20; i++)
            {
                var randHole = spawnPoints.GetRandomObject();
                if (randHole.free)
                {
                    var topo = instantiator.Instantiate(randHole.transform);
                    topo.GetComponent<Topo>().hole = randHole;
                    topo.GetComponent<Topo>().OnDespawn = OnTopoDespawn;
                    topo.transform.parent = floorParent;
                    return;
                }
            }
            //look for available hole
            for (int i = 0; i < spawnPoints.objects.Count; i++)
            {
                var hole = spawnPoints.GetObject(i);
                if (hole.free) { 
                    var topo = instantiator.Instantiate(hole.transform);
                    topo.GetComponent<Topo>().hole = hole;
                    topo.GetComponent<Topo>().OnDespawn = OnTopoDespawn;
                    topo.transform.parent = floorParent;
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