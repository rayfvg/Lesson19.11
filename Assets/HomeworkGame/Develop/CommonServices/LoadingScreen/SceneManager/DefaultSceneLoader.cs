using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultSceneLoader : ISceneLoader
{
    public IEnumerator LoadAsync(SceneId sceneId, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        AsyncOperation waitLoading =  SceneManager.LoadSceneAsync(sceneId.ToString(), loadSceneMode);

        while(waitLoading.isDone == false)
            yield return null;
    }
}
