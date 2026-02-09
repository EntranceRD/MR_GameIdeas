using Entrance.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entrance;
using System;
using Entrance.Unity;

namespace EntranceGames.Pursuers
{
    public class PlayerLocator : MonoBehaviour/*, IInteractible*/
    {
        #region UNITY METHODS
        private void Start()
        {
            Initialize();
        }

        private void FixedUpdate()
        {
            interactionCleaningTimer.Tick(Time.fixedDeltaTime);
        }
        #endregion

        #region VARIABLES
        [SerializeField, Range(0, 10)] private float RoomWidth = 8.94f, RoomLength = 7.61f;
        [SerializeField, Range(0, 1)] private float CellSizeX = 0.1f, CellSizeZ = 0.1f;
        [SerializeField] private GameObject CellPrefab;
        //[SerializeField] private PursuersController pursuersController;

        private List<Vector3> interactionPoints;
        [SerializeField] private Timer interactionCleaningTimer;
        //public Action<Entrance.Interaction.Touch> OnInteract { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region PUBLIC METHODS
        public void Initialize()
        {
            interactionPoints = new List<Vector3>();
            interactionCleaningTimer.OnFinish = () => {
                interactionPoints.Clear();
                interactionCleaningTimer.Restart();
            };
            interactionCleaningTimer.Restart();

            int width = ((int)(RoomWidth / CellSizeX)) + 1;
            int length = ((int)(RoomLength / CellSizeZ)) + 1;
            Debug.Log($"W {width} | L {length}");
            CreateInteractiveGrid(width, length);      
        }
        public Vector3 FindClosestPointTo(Vector3 pursuerPosition) {
            var pursuerMag = pursuerPosition.magnitude;
            float interactiveMag = 0f;
            float closestMag = 100f;
            var diff = 100f;
            int closestPoint = -1;
            for (int i = 0; i < interactionPoints.Count; i++)
            {
                interactiveMag = interactionPoints[i].magnitude;
                diff = Mathf.Abs(interactiveMag - pursuerMag);
                if (diff < closestMag) { closestMag = diff; closestPoint = i; }
            }
            if (closestPoint >= 0) { return interactionPoints[closestPoint]; }
            return Vector3.zero;
        }
        //public void Interact(Entrance.Interaction.Touch touch)
        //{
        //    Debug.Log($"Registered a interaction at {touch.position}");
        //}
        #endregion

        #region PRIVATE METHODS
        private void LocatedPlayerForPursuer(Vector3 position)
        {
            //Debug.Log($"Registered a interaction at {position}");
            interactionPoints.Add(position);
            //pursuersController.SetPursuitTarget(position);
        }
        private void CreateInteractiveGrid(int width, int length) {
            Vector3 position = Vector3.zero;
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < length; z++)
                {
                    var cell = GameObject.Instantiate(CellPrefab, transform);
                    cell.transform.localPosition = position;
                    var plc = cell.GetComponent<PlayerLocatorCell>();
                    plc.Initialize(CellSizeX, CellSizeZ);
                    plc.OnClick = LocatedPlayerForPursuer;
                    position.z += CellSizeZ;
                }
                position.x += CellSizeX;
                position.z = 0;
            }
        }
        #endregion
    }
}