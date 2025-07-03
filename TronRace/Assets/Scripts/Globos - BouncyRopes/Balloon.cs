using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class Balloon : MonoBehaviour, LifeElement
    {
        #region UNITY METHODS
        private void Start()
        {
            Heal(MaxHealth);
            if (OnDie == null) { 
            OnDie += KillPhysichs;
            OnDie += RecycleBalloon;
            OnDie += CallExplosion;
            }
        }

        private void Update()
        {
            
        }
        #endregion

        #region VARIABLES
        public Action OnDie { get; set; }
        public int Health { get; protected set; }
        [SerializeField] private int MaxHealth = 1;
        [SerializeField] private PoolableObject poolable;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private ColorChanger material;
        private Color col;
        #endregion

        #region PUBLIC METHODS
        public void SetColor(Color newColor) {
            material.ChangeColor(newColor);
            col = newColor;
        }
        public void SetDrag(float drag) {
            rb.drag = drag;
        }
        public void SetMovementConstraints(bool x, bool y, bool z) {

            RigidbodyConstraints constraints = RigidbodyConstraints.None;

            if (x) constraints |= RigidbodyConstraints.FreezePositionX;
            if (y) constraints |= RigidbodyConstraints.FreezePositionY;
            if (z) constraints |= RigidbodyConstraints.FreezePositionZ;

            constraints |= RigidbodyConstraints.FreezeRotation;
            rb.constraints = constraints;
        }
        public void Heal(int heal)
        {
            Health = Math.Min(Health + heal, MaxHealth);
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(Health - damage, 0);
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
        private void RecycleBalloon()
        {
            poolable.Recycle();    
        }
        private void KillPhysichs() {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        private void CallExplosion() {
            BalloonExplosionInstantiator.Instance.CreateExplosion(transform, col);
        }
        #endregion
    }
}