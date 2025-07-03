using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class LifeObject : MonoBehaviour, LifeElement
    {
        #region UNITY METHODS
        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        private int varA = 0;
        public Action OnDie { get; set; }
        public Action OnTakeDamage { get; set; }
        public Action OnHeal { get; set; }
        public int Health { get; protected set; }
        [SerializeField] protected int MaxHealth = 1;
        #endregion

        #region PUBLIC METHODS
        public void Heal(int heal)
        {
            Health = Math.Min(Health + heal, MaxHealth);
            OnHeal?.Invoke();
        }

        public void TakeDamage(int damage)
        {
            //if (!isAlive()) return;
            Health = Math.Max(Health - damage, 0);
            OnTakeDamage?.Invoke();
            if (!isAlive())
            {
                OnDie?.Invoke();
            }
        }

        public bool isAlive()
        {
            return Health > 0;
        }
        #endregion


        #region PRIVATE METHODS
        private void method()
        {
            
        }
        #endregion
    }
}