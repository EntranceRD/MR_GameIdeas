using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entrance.General.Video
{
    [System.Serializable]
    public class VideoSettings
    {
        public string VideoName;
        public string VideoType = "mp4";
        public int Volume = 100;
        public bool Loop = false;
    }
}