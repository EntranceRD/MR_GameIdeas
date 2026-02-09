using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Object scene;
    [SerializeField, Range(0, 10f)] private float waitTime = 3f;
    private bool changingScene = false;

    public void ChangeScene() {
        SceneManager.LoadScene(1);

        //if (scene == null) return;
        //if (changingScene) return;
        //changingScene = true;
        //StartCoroutine(ChangeScene(waitTime));
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private IEnumerator ChangeScene(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene.name);
        //var ao = SceneManager.LoadSceneAsync(scene.name);
        //ao.allowSceneActivation = false;

        //yield return new WaitForSeconds(time);
        //ao.allowSceneActivation = true;
    }
}