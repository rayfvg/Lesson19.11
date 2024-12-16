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
    private GameplayRulesPresenter _gameplayUserInputFactory;

    private DIContainer _container;

    private IGame _game;
    private Gameplay _gameNumbers;
    private Gameplay _gameLatters;

    private bool _initializedComplited;
    public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
    {
        _container = container;
        

        InitializedConfig();
        _gameNumbers = new Gameplay(_container, _startGameConfig.StartGameSettings.GetLatters(GameModes.Numbers), _container.Resolve<PlayerDataProvider>());
        _gameLatters = new Gameplay(_container, _startGameConfig.StartGameSettings.GetLatters(GameModes.Letters), _container.Resolve<PlayerDataProvider>());
        ProcessRegisrations();


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

    private void ProcessRegisrations()
    {
        _container.RegisterAsSingle(c => new GameplayPresenterFactory(c, _gameNumbers, _gameLatters));

        _container.RegisterAsSingle(c =>
        {
            GameplayUIRoot gameplayUIRoot = c.Resolve<ResourcesAssetsLoader>().LoadResource<GameplayUIRoot>("Gameplay/UI/GameplayUItRoot");
            return Instantiate(gameplayUIRoot);
        }).NonLazy();

        GameplayUIRoot gameplayUIRoot = _container.Resolve<GameplayUIRoot>();
        _gameplayUserInputFactory = _container.Resolve<GameplayPresenterFactory>().CreateGameplayUserInputPresent(gameplayUIRoot._inputUserView);

        _gameplayUserInputFactory.Initialize();
    }

    private void InitializedConfig()
    {
        _startGameConfig = _container.Resolve<ConfigsProviderService>();
        _container.Initialize();
    }
    private void StartGameNumbers()
    {
        _game = _gameNumbers;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(_gameNumbers.ProcessGeneration());
    }

    private void StartGameLetters()
    {
        _game = _gameLatters;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(_gameLatters.ProcessGeneration());
    }

    private void Update()
    {
        if (_initializedComplited)
        {
            _game.Update();
        }
    }
}
