using Entrance.Tron;
using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class RecordPlayer : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            if (recordedInstructions == null) { 
            recordedInstructions = new ObjectGroup<RecordableTravelerInstruction>();
            }
        }
        private void Start()
        {
            traveler.OnDirectionChange += RecordTraveler;
            if (replaying) {
                //StartCoroutine(AutomaticInstructions());
                instructionTimer = recordedInstructions.GetObject(0).time;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) { Activate(); }
            if (recording) { 
                instructionTimer += Time.deltaTime;
            }

            if (awaitingActivation) return;
            if (!replaying) return;
            CheckReplayInstruction();
        }
        #endregion

        #region VARIABLES
        [SerializeField] private bool awaitingActivation = true;
        [SerializeField] private bool recording = false;
        [SerializeField] private bool replaying = false;
        [SerializeField] private Navmeshable_Traveler traveler;
        private float instructionTimer = 0f;
        [SerializeField] private ObjectGroup<RecordableTravelerInstruction> recordedInstructions;
        private int currentInstruction = 0;
        
        [System.Serializable]
        public class RecordableTravelerInstruction {
            public float time;
            public MovementDirections direction;
        }
        #endregion

        #region PUBLIC METHODS
        public void Activate()
        {
            awaitingActivation = false;
        }
        #endregion

        #region PRIVATE METHODS
        private IEnumerator AutomaticInstructions() {
            var inst = recordedInstructions.GetObject(currentInstruction);
            yield return new WaitForSecondsRealtime(inst.time);
            traveler.SetMovement(inst.direction);
            currentInstruction = Mathf.Min(currentInstruction + 1, recordedInstructions.objects.Count - 1);
            StartCoroutine(AutomaticInstructions());
            yield return null;
        }
        private void CheckReplayInstruction() {
            instructionTimer -= Time.deltaTime;
            if (instructionTimer > 0) { return; }
            var next = Mathf.Min(currentInstruction+1, recordedInstructions.objects.Count-1);

            ReplayInstruction(currentInstruction,next);
            currentInstruction = next;
        }
        private void ReplayInstruction(int instruction, int nextInstruction) {
            var inst = recordedInstructions.GetObject(instruction);
            var n_inst = recordedInstructions.GetObject(nextInstruction);
            traveler.SetMovement(inst.direction);
            instructionTimer = n_inst.time;
        }
        private void RecordTraveler(MovementDirections direction)
        {
            if (!recording) return;
            var newInstruction = new RecordableTravelerInstruction()
            {
                direction = direction,
                time = instructionTimer
            };
            recordedInstructions.Add(newInstruction);
            instructionTimer = 0f;
        }
        #endregion
    }
}