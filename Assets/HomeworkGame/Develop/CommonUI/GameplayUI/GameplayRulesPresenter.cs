using System;
using UnityEngine;

public class GameplayRulesPresenter 
{
   private ConfigsProviderService _configProviderService;
    private TextWithValue _view;
    private Gameplay _gameplay;

    public GameplayRulesPresenter(ConfigsProviderService configProviderService, TextWithValue textValue, DIContainer conteiner, Gameplay gameplay)
    {
        _configProviderService = configProviderService;
        _view = textValue;
        _gameplay = gameplay;
    }

    public void Initialize()
    {
        _view.SetText("Повторите: ");
 
        _gameplay.CharsAdded += OnCharChanged;
    }

    private void OnCharChanged(char newChar)
    {
        _view.SetValue(newChar.ToString());
    }

    public void Dispose()
    {
        _gameplay.CharsAdded -= OnCharChanged;
    }
}
