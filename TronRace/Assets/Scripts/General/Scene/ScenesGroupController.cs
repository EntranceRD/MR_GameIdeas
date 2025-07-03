using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Entrance.Scene
{

    public class ScenesGroupController : MonoBehaviour
    {
        #region UNITY METHODS
        private void OnEnable()
        {
            if (loadedScenes == null) {
                loadedScenes = new AsyncOperationHandle<SceneInstance>[scenes.Length];
            }
            //foreach (var scene in scenes) {
            //    if (loadedScenes.ContainsKey(scene)) {
            //        loadedScenes.Add(scene, new AsyncOperationHandle<SceneInstance>());
            //    }
            //}
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                LoadScenes();
            }
            if (Input.GetKeyDown(KeyCode.Delete)) {
                UnloadScenes();
            }
        }
        #endregion

        #region VARIABLES
        public string[] scenes;

        private AsyncOperationHandle<SceneInstance>[] loadedScenes;
        #endregion

        #region PUBLIC METHODS
        public void LoadScenes()
        {
            for (int sceneIndex = 0; sceneIndex < scenes.Length; sceneIndex++) {
                LoadScene(sceneIndex);
            }
        }
        public void UnloadScenes() 
        {
            for (int sceneIndex = 0; sceneIndex < scenes.Length; sceneIndex++){
                UnloadScene(sceneIndex);
            }
        }
        #endregion

        #region PRIVATE METHODS
        private void LoadScene(int sceneIndex)
        {
            if (loadedScenes[sceneIndex].IsValid()) return;
            Addressables.UnloadSceneAsync(loadedScenes[sceneIndex]);
        }
        private void UnloadScene(int sceneIndex) {
            if (!loadedScenes[sceneIndex].IsValid()) return;
            loadedScenes[sceneIndex] = Addressables.LoadSceneAsync(scenes[sceneIndex], LoadSceneMode.Additive);
        }
        #endregion
    }
}