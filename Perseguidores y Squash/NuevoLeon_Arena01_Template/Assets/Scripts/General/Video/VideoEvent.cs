using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;
namespace Entrance.General.Video
{
    public class VideoEvent : MonoBehaviour
    {
        private void OnEnable()
        {

        }

        [SerializeField] private VideoPlayer player;
        public UnityEvent OnFinished;

        public void AwaitVideo()
        {
            StopAllCoroutines();
            StartCoroutine(VideoWait());
        }
        private IEnumerator VideoWait()
        {
            while (player.isPlaying)
            {
                yield return new WaitForSeconds(1);
            }
            OnFinished?.Invoke();
        }
    }
}