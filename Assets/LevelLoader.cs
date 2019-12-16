using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Android;

public class LevelLoader : MonoBehaviour
{

    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {

            Permission.RequestUserPermission(Permission.Camera);

        }
    }
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronous(sceneIndex));

    }
    
    IEnumerator LoadAsynchronous (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            yield return null;
        }
    }
}
