using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance
{
    public interface LifeElement
    {
        System.Action OnDie { get; set; }

        void Heal(int heal);
        void TakeDamage(int damage);
        bool isAlive();
    }
}