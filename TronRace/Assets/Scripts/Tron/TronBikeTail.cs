using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Tron
{
    public class TronBikeTail : MonoBehaviour
    {
        #region UNITY METHODS
        private void Awake()
        {
            KillBehaviour();
            RestartTail(transform);
        }
        private void Start()
        {
            traveler.OnDirectionChange += (direction) =>
            {
                moving = true;
                distanceInstantiator.RegisterPosition(transform.position);
                var instruction = CreateInstanceInstructionFor(transform.position);
                instructions.Enqueue(instruction);
            };

            player.OnDie += KillBehaviour;
        }

        private void Update()
        {
            if (!moving) return;

            Vector3 position = transform.position;
            if (distanceInstantiator.HasToInstantiate(position)) {
                //Debug.Log($"Registering new position {transform.position} when last one was {lastInstancePosition}");
                distanceInstantiator.RegisterPosition(position);
                var instruction = CreateInstanceInstructionFor(position);
                instructions.Enqueue(instruction);
            }

            var deltaTime = Time.deltaTime;
            foreach (var instruction in instructions) {
                instruction.instanceTimer.Tick(deltaTime);
            }
        }
        private void LateUpdate()
        {
            //Dequeue is deferred to LateUpdate to avoid modifying the collection during iteration
            if (requiredDequeueInstructions<=0) return;
            for (int i = 0; i < requiredDequeueInstructions; i++)
            {
                instructions.Dequeue();
            }
            requiredDequeueInstructions = 0;
        }
        #endregion

        #region VARIABLES
        [SerializeField] private Navmeshable_Traveler traveler;

        [SerializeField] private TronPlayer player;
        private bool moving = false;

        [SerializeField] private TailGeneration tailGenerator;
        private Queue<InstanceInstruction> instructions = new Queue<InstanceInstruction>();
        [SerializeField] private TailVisual visualTail;
        [SerializeField] private DistanceInstantiator distanceInstantiator;
        private int requiredDequeueInstructions = 0;
        #endregion

        #region PUBLIC METHODS
        public void RestartTail(Transform startPosition)
        {
            distanceInstantiator.RegisterPosition(startPosition.position);
            //distanceInstantiator.RegisterPosition(transform.position);
            visualTail.Restart();
        }
        public void ForceStart() { moving = true; }
        #endregion

        #region PRIVATE METHODS
        private void KillBehaviour() {
            tailGenerator.RecycleTail();
            instructions.Clear();
            visualTail.Stop();
            moving = false;
        }
        private InstanceInstruction CreateInstanceInstructionFor(Vector3 position) {
            var instruction = new InstanceInstruction(position, 0.6f, () => {
                //var instruction = new InstanceInstruction(position, 1.0f, () => {
                tailGenerator.SpawnTailSegmentOn(position);
                ++requiredDequeueInstructions;
            });
            return instruction;
        }
        #endregion
    }
}