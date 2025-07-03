using Entrance;
using Entrance.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squash
{
    public class PhantomLeader : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            spawning = true;
            foreach (var follower in followers.objects) {
                follower.SetVisibility(tailVisibility);
            }
        }
        private void OnDisable()
        {
            spawning = false;
        }
        private void Start()
        {
            followerSpawnTimer = new Timer();
            followerLifetime = followers.objects.Count * 0.1f;
            followerSpawnTimer.Target = 0.1f;
            followerSpawnTimer.OnFinish = () =>
            {
                followerSpawnTimer.Restart();
                SpawnFollower();
            };
            followerSpawnTimer.Restart();
        }

        private void Update()
        {
            if (!spawning) return;
            followerSpawnTimer.Tick(Time.deltaTime);
        }
        #endregion

        #region VARIABLES
        public bool tailVisibility = false;
        public ObjectGroup<PhantomFollower> followers;
        private Timer followerSpawnTimer;
        private float followerLifetime = 0f;
        private bool spawning = false;
        #endregion

        #region PUBLIC METHODS
        public void DespawnFollowers()
        {
            foreach (var follower in followers.objects)
            {
                follower.Despawn();
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void SpawnFollower()
        {
            foreach (var follower in followers.objects)
            {
                if (!follower.Alive)
                {
                    follower.Spawn(transform.position, followerLifetime);
                    return;
                }
            }
        }
        #endregion
    }
}