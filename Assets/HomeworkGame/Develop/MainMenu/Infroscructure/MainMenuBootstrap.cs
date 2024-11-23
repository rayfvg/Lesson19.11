using System.Collections;
using UnityEngine;

public class MainMenuBootstrap : MonoBehaviour
{
    private DIContainer _container;

    private UserInput _userInput;

    private void Awake()
    {
        _userInput = new UserInput();
    }

    private void Update()
    {
        if (_userInput.UserSelect(KeyCode.Alpha1))
        {
            Debug.Log("Нажал 1");
            _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(1)));
        } 
        
        if (_userInput.UserSelect(KeyCode.Alpha2))
        {
            Debug.Log("Нажал 2");
            _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(2)));
        }
    }

    public IEnumerator Run(DIContainer container, MainMenuInputArgs maimMenuInputArgs)
    {
        _container = container;

        ProcessRegisrations();

        yield return new WaitForSeconds(1);
    }

    private void ProcessRegisrations()
    {
        //регистрации сцены геймплея
    }

  
}
