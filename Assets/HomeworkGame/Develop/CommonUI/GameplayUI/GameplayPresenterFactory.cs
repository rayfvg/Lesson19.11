using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPresenterFactory 
{
    private DIContainer _container;
    private ConfigsProviderService _configProviderService;
    private Gameplay _gameplay;

    public GameplayPresenterFactory(DIContainer container, Gameplay gameplay)
    {
        _configProviderService = container.Resolve<ConfigsProviderService>();
        _container = container;
        _gameplay = gameplay;
    }

    public GameplayRulesPresenter CreateGameplayUserInputPresent(TextWithValue textView) =>
        new GameplayRulesPresenter(_configProviderService, textView, _container, _gameplay);
}