using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPresenterFactory 
{
    private DIContainer _container;
    private ConfigsProviderService _configProviderService;

    public GameplayPresenterFactory(DIContainer container)
    {
        _configProviderService = container.Resolve<ConfigsProviderService>();
        _container = container;
    }

    public GameplayRulesPresenter CreateGameplayUserInputPresent(TextWithValue textView) =>
        new GameplayRulesPresenter(_configProviderService, textView, _container);
}