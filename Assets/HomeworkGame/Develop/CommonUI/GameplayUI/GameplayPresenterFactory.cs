using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPresenterFactory 
{
    private DIContainer _container;
    private ConfigsProviderService _configProviderService;
    private Gameplay _gameplay;
    private Gameplay _gameplayLatter;

    public GameplayPresenterFactory(DIContainer container, Gameplay gameplay, Gameplay gameplayLatter)
    {
        _configProviderService = container.Resolve<ConfigsProviderService>();
        _container = container;
        _gameplay = gameplay;
        _gameplayLatter = gameplayLatter;
    }

    public GameplayRulesPresenter CreateGameplayUserInputPresent(TextWithValue textView) =>
        new GameplayRulesPresenter(_configProviderService, textView, _container, _gameplay, _gameplayLatter);
}