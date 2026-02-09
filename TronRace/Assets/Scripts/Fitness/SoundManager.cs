using UnityEngine;
using System.Collections.Generic;

namespace Entrance.Games
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public List<AudioClip> audioClips;

        public void PlaySound(int index)
        {
            if (index >= 0 && index < audioClips.Count)
            {
                audioSource.PlayOneShot(audioClips[index]);
            }
        }

        public void StopSounds()
        {
            audioSource.Stop();
        }
    }
}