using System.Collections;
using UnityEngine;

public class MainMenuBootstrap : MonoBehaviour
{
    private DIContainer _container;
    private SceneSelection _sceneSelection;

    private bool _isInitialized = false;

    public IEnumerator Run(DIContainer container, MainMenuInputArgs maimMenuInputArgs)
    {
        _container = container;

        ProcessRegisrations();


        yield return new WaitForSeconds(1);
    }

    private void Update() //imSorry(
    {
        if (_isInitialized == false)
            return;

        _sceneSelection.Update();
    }

    private void ProcessRegisrations()
    {
       _sceneSelection = _container.Resolve<SceneSelection>();
        _isInitialized = true;
    }

  
}
