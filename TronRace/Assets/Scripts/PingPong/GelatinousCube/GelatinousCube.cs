using Entrance.Interaction;
using Entrance.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class GelatinousCube : MonoBehaviour, IInteractible
    {
        #region UNITY METHODS
        private void Awake()
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }

        private void Start()
        {
            interactionTime.OnFinish = () =>
            {
                interactionTime.Restart();
                life.TakeDamage(damagePerInteraction);
                ChangeJelloOpacity();
            };
            block = new MaterialPropertyBlock();
            life.OnDie = () => { 
                pool.Recycle();

                if (drop.isTimes2) { 
                    scoreManager.ApplyTimes2();
                }else 
                {
                    scoreManager.AddPoints(drop.selectedModifier);
                }

                if (position != null) { 
                    position.free = true;
                }
            };
            interactionTime.Restart();
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        [SerializeField] private LifeObject life;
        [SerializeField] private PoolableObject pool;
        [SerializeField] private Timer interactionTime;
        [SerializeField] private Renderer rend;

        [SerializeField] private GelatinousCubeDrop drop;
        [SerializeField] private ScoreManager scoreManager;

        [SerializeField, Range(0, 100)] private int damagePerInteraction=20;
        public Action<Interaction.Touch> OnInteract { get; set; }
        private MaterialPropertyBlock block;
        private GelatinousPosition position;
        #endregion

        #region PUBLIC METHODS
        public void SetGelatinousPosition(GelatinousPosition pos) { position = pos; }
        public void Restart() {
            ChangeJelloOpacity();
            interactionTime.Restart();
        }
        public void Interact(Interaction.Touch touch)
        {
            //Debug.Log("Interaction");
            interactionTime.Tick(Time.deltaTime);
        }
        #endregion

        #region PRIVATE METHODS
        private void ChangeJelloOpacity()
        {
            if (block == null) {
                block = new MaterialPropertyBlock();
            }
            rend.GetPropertyBlock(block);
            var color = block.GetColor("_Color");
            color.a = life.Health / 100.0f;
            block.SetColor("_Color", color);
            rend.SetPropertyBlock(block);
        }
        #endregion
    }
}