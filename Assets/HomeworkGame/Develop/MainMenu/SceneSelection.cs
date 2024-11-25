using UnityEngine;

public class SceneSelection 
{
    private UserInput _userInput;
    private DIContainer _container;

    public SceneSelection(DIContainer dIContainer)
    {
        _container = dIContainer;
        _userInput = _container.Resolve<UserInput>();
    }

    public void Update()
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
}
