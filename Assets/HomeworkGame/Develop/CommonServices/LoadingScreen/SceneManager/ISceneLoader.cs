using System.Collections;
using UnityEngine.SceneManagement;

public interface ISceneLoader
{
  IEnumerator LoadAsync(SceneId sceneId, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
}
