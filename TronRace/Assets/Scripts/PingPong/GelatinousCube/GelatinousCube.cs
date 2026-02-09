using Entrance.Interaction;
using Entrance.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entrance.Games;

namespace Entrance 
{
    public class GelatinousCube : MonoBehaviour, IInteractible
    {
        #region UNITY METHODS

        private void Start()
        {
            interactionTime.OnFinish = () =>
            {
                interactionTime.Restart();
                life.TakeDamage(damagePerInteraction);
                ChangeJelloOpacity();
            };
            block = new MaterialPropertyBlock();
            life.OnDie = () =>
            {
                StartCoroutine(DieRoutine());
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
        public ScoreManager scoreManager;
        [SerializeField] private GelatinousCubeDrop drop;

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

        private IEnumerator DieRoutine()
        {
            yield return StartCoroutine(drop.ShowModifier());

            switch (drop.modifier.type)
            {
                case ModifierType.PlusOne:
                    scoreManager.AddPoints(1);
                    break;
                case ModifierType.PlusThree:
                    scoreManager.AddPoints(3);
                    break;
                case ModifierType.TimesTwo:
                    //ScoreManager.Instance.ApplyTimes2();
                    break;
            }

            pool.Recycle();

            if (position != null)
                position.free = true;
        }

        #endregion
    }
}