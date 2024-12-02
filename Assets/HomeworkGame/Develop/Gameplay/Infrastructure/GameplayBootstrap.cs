using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameModes
{
    Numbers = 1,
    Letters = 2
}

public class GameplayBootstrap : MonoBehaviour
{
    private ConfigsProviderService _startGameConfig;


    private DIContainer _container;

    private IGame _game;

    private bool _initializedComplited;
    public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
    {
        _container = container;

        InitializedConfig();
        
        if (gameplayInputArgs.LevelNumber == (int)GameModes.Numbers)
        {
            StartGameNumbers();
            PlayerPrefs.SetInt("SceneId", (int)GameModes.Numbers);
        }
        if (gameplayInputArgs.LevelNumber == (int)GameModes.Letters)
        {
            StartGameLetters();
            PlayerPrefs.SetInt("SceneId", (int)GameModes.Letters);
        }


        yield return new WaitForSeconds(1);

        _initializedComplited = true;
    }

    private void InitializedConfig()
    {
        _startGameConfig = _container.Resolve<ConfigsProviderService>();
        _container.Initialize();
    }
    private void StartGameNumbers()
    {
        Gameplay gameLetters = new Gameplay(_container, _startGameConfig.StartGameSettings.GetLatters(GameModes.Numbers));
        _game = gameLetters;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(gameLetters.ProcessGeneration());
    }

    private void StartGameLetters()
    {
        Gameplay gameLetters = new Gameplay(_container, _startGameConfig.StartGameSettings.GetLatters(GameModes.Letters));
        _game = gameLetters;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(gameLetters.ProcessGeneration());
    }

    private void Update()
    {
        if (_initializedComplited)
        {
            _game.Update();
        }
    }
}
