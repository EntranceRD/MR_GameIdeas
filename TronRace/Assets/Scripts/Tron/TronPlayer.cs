using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.Tron
{
    public class TronPlayer : MonoBehaviour, LifeElement
    {
        #region UNITY METHODS
        private void Awake()
        {
            Heal(MaxHealth);
            OnDie += KillAllBehaviours;
            OnDie += CallExplosion;
        }

        private void Update()
        {
            //Testing methods
            //if (Input.GetKeyDown(KeyCode.Backspace)) { KillAllBehaviours(); }
            //if (Input.GetKeyDown(KeyCode.Return)) { Restart(); }
        }
        #endregion

        #region VARIABLES
        //public PlayerController controller;
        public ButtonEvent automatizationOnDead;
        public Action OnDie { get; set; }
        public int Health { get; protected set; }
        [SerializeField]private int MaxHealth = 1;

        [SerializeField] private Navmeshable_Traveler movementController;
        [SerializeField] private Collider interactionCollider;
        [SerializeField] private Renderer objectVisualization;
        [SerializeField] private ParticleSystem explosion;
        #endregion

        #region PUBLIC METHODS
        public void Heal(int heal)
        {
            Health = Math.Min(Health + heal, MaxHealth);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(Health -damage, 0);
            if (!isAlive()) {
                KillAllBehaviours();
                OnDie?.Invoke();
                automatizationOnDead.Call();
            }
        }

        public bool isAlive()
        {
            return Health > 0;
        }
        public void RestartTronPlayer() {
            KillAllBehaviours();
            movementController.canMove = true;
            interactionCollider.enabled = true;
            objectVisualization.enabled = true;
            Heal(MaxHealth);
        }
        #endregion

        #region PRIVATE METHODS
        private void CallExplosion() {
            explosion.transform.position = transform.position;
            explosion.Play();
        }
        private void KillAllBehaviours()
        {
            movementController.StopMovement();
            interactionCollider.enabled = false;
            objectVisualization.enabled = false;
        }
        #endregion
    }
}
