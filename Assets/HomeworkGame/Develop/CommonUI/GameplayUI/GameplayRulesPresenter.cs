using UnityEngine;

public class GameplayRulesPresenter 
{
   private ConfigsProviderService _configProviderService;
    private TextWithValue _view;

    public GameplayRulesPresenter(ConfigsProviderService configProviderService, TextWithValue textValue, DIContainer conteiner)
    {
        _configProviderService = configProviderService;
        _view = textValue;
    }

    public void Initialize()
    {
        _view.SetText("Повторите: ");
        var letters = _configProviderService.StartGameSettings.GetLatters(GameModes.Numbers);
        _view.SetValue(string.Join(", ", letters));
    }

    public void Dispose()
    {
        //
    }

}
