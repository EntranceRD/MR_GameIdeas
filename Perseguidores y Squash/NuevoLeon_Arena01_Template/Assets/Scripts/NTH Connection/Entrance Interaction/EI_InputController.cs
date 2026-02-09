using Entrance.General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Interaction
{
    public class EI_InputController : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            Instance = this;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O)) {
                SwitchInteractionMethod(InteractionMethods.ORTOGRAPHIC);
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                SwitchInteractionMethod(InteractionMethods.PERSPECTIVE);
            }
        }
        #endregion

        #region VARIABLES
        public static EI_InputController Instance;
        public InteractionMethods InteractionMethod = InteractionMethods.ORTOGRAPHIC;
        public Camera[] cameras;
        public Transform[] surfacePivots;
        public Color[] surfaceColorDebug = new Color[] { Color.yellow, Color.yellow, Color.yellow, Color.yellow, Color.yellow, Color.yellow };
        #endregion

        #region PUBLIC METHODS
        public void CheckInteractions(Vector3 direction, params Vector3[] points)
        {
            switch (InteractionMethod) {
                case InteractionMethods.ORTOGRAPHIC:
                    var orientation = GetOrientationIndex(direction);
                    if (orientation < 0) return;
                    var surface = surfacePivots[orientation];
                    foreach (var point in points)
                    {
                        var pos = point + surface.position;
                        //Debug.DrawLine(point, point + (direction * 30), Color.yellow);
                        Debug.DrawLine(pos, pos + (direction * 30), surfaceColorDebug[orientation]);
                        //Debug.DrawLine(pos, pos + (direction * 30), Color.yellow);
                        RaycastHit hit;
                        if (Physics.Raycast(pos, direction, out hit, 30))
                        //if (Physics.Raycast(point, direction, out hit, 30))
                        {
                            CreatePointInteraction(hit);
                        }
                    }
                    return;
                case InteractionMethods.PERSPECTIVE:
                    var orientationIndex = GetOrientationIndex(direction);
                    if (orientationIndex == -1) return;

                    var cam = cameras[orientationIndex];
                    var camPos = cam.transform.position;

                    var surface_pos = surfacePivots[orientationIndex].position;

                    foreach (var point in points)
                    {
                        var dir = ((point + surface_pos) - camPos).normalized;
                        //Debug.DrawLine(camPos,camPos + (dir*30), Color.red);

                        RaycastHit hit;
                        if (Physics.Raycast(camPos, dir, out hit, 30))
                        {
                            CreatePointInteraction(hit);
                        }
                    }
                    return;
            }
        }
        public void SwitchInteractionMethod(InteractionMethods method) {
            InteractionMethod = method;
            bool orto = false;
            switch (method) {
                case InteractionMethods.ORTOGRAPHIC: orto = true; break;
                case InteractionMethods.PERSPECTIVE: orto = false; break;
            }
            foreach (var cam in cameras)
            {
                cam.orthographic = orto;
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void CreatePointInteraction(RaycastHit hit) {
            var pos = new Vec3(hit.point.x, hit.point.y, hit.point.z);
            var interactible = hit.collider.GetComponent<IInteractible>();
            if (interactible != null)
                interactible.Interact(new Entrance.Interaction.Touch(pos));
        }
        private int GetOrientationIndex(Vector3 direction)
        {
            for (int i = 0; i < surfacePivots.Length; i++)
            {
                var angle = Vector3.Angle(direction, surfacePivots[i].forward);
                if (angle < 10)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}