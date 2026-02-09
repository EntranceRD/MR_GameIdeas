using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Entrance.General.Video;
using UnityEngine.UI;

namespace Entrance.General
{
    public class VideoLoader : MonoBehaviour
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
        //public string fileName = "Video Test";
        [SerializeField] private VideoPlayer player;
        [SerializeField] private Material SampleVideoMaterial;
        [SerializeField] private bool scaleToMatchResolution = true;
        [SerializeField] private Vector2 scaler = Vector2.one;
        public Vector2Int resolution;
        public float duration;
        public ObjectGroup< Image> renderers;
        private RenderTexture videoTexture;
        private Material videoMaterial;
        #endregion

        #region PUBLIC METHODS
        public void AddRenderer(params Image[] renderer) { renderers.objects.AddRange(renderer); }
        public void LoadVideo(VideoSettings settings) { LoadVideoFromSettings(settings); }
        public void LoadVideo(string settingsFile)
        {
            var setting = GetVideoSettings(settingsFile);
            LoadVideoFromSettings(setting);
        }
        public void PlayVideo()
        {
            //if (scaleToMatchResolution)
            //{
            //    ScaleRenderersToResolution(resolution);
            //}
            //SetupDisplaysWithVideoMaterial();
            //player.targetTexture = videoTexture;
            player.Play();
        }
        #endregion

        #region PRIVATE METHODS
        private void ScaleRenderersToResolution(Vector2Int resolution)
        {
            var res = new Vector2(resolution.x * scaler.x, resolution.y * scaler.y) / 1000f;
            renderers.SimpleIteration((obj) => { obj.transform.localScale = res; });
        }
        private void SetupDisplaysWithVideoMaterial()
        {
            renderers.SimpleIteration((obj) => { obj.material = videoMaterial; });

            videoTexture = new RenderTexture(resolution.x, resolution.y, 32);
            videoMaterial.SetTexture("_MainTex", videoTexture);
        }
        private void LoadVideoFromSettings(VideoSettings setting)
        {
            player.source = VideoSource.Url;
            player.url = $"{Application.streamingAssetsPath}/Videos/{setting.VideoName}.{setting.VideoType}";
            player.isLooping = setting.Loop;
            player.targetTexture = videoTexture;
            videoMaterial = new Material(SampleVideoMaterial);
            StartCoroutine(PrepareVideo());
        }
        private VideoSettings GetVideoSettings(string settingsFile)
        {
            var path = $"{Application.streamingAssetsPath}/Video Settings/{settingsFile}.json";
            var json = System.IO.File.ReadAllText(path);
            return JsonUtility.FromJson<VideoSettings>(json);
        }
        private IEnumerator PrepareVideo()
        {
            player.Prepare();
            while (!player.isPrepared)
                yield return null;

            resolution = new Vector2Int((int)player.width, (int)player.height);
            duration = (float)player.length;

            if (scaleToMatchResolution)
            {
                ScaleRenderersToResolution(resolution);
            }
            SetupDisplaysWithVideoMaterial();
            player.targetTexture = videoTexture;
        }
        #endregion
    }
}