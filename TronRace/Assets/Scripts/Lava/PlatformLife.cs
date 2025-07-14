using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance 
{
    public class PlatformLife : MonoBehaviour
    {
        #region UNITY METHODS
        private void Start()
        {
     
        }

        private void Update()
        {
            damageInterval.Tick(Time.deltaTime);

        }
        #endregion

        #region VARIABLES
        [SerializeField] private PoolableObject pool;
        [SerializeField] private LifeObject life;
        [SerializeField] private Timer totalLifeTime;
        [SerializeField] private UnityEngine.UI.Image maskFiller;
        private Timer damageInterval;
        #endregion

        #region PUBLIC METHODS
        public void Restart()
        {
            Initialize();
            life.Heal(life.GetMaxHealth());

            damageInterval.Restart();
            totalLifeTime.Restart();
        }
        #endregion

        #region PRIVATE METHODS
        private void Initialize()
        {
            if (damageInterval == null)
            {
                damageInterval = new Timer();
                damageInterval.Target = totalLifeTime.Target / life.GetMaxHealth();
            }
            damageInterval.OnFinish = () =>
            {
                totalLifeTime.Tick(damageInterval.Target);
                damageInterval.Restart();
                life.TakeDamage(1);
                maskFiller.fillAmount = 0.65f + (.35f * (life.Health / 100f));
            };
            totalLifeTime.OnFinish = () => {
                pool.Recycle();
            };

            //Restart();
        }
        #endregion
    }
}