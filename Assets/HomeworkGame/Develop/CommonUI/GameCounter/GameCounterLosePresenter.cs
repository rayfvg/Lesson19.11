using UnityEngine;

public class GameCounterLosePresenter
{
    private GameCounterService _gameCounterService;

    private TextWithValue _view;

    public GameCounterLosePresenter(GameCounterService gameCounterService, TextWithValue textValue, DIContainer conteiner)
    {
        _gameCounterService = gameCounterService;
        _view = textValue;
    }

    public void Initialize()
    {
        _view.SetText("Количество поражений");
        _view.SetValue(_gameCounterService.LoseCount.ToString());
    }

    public void Dispose()
    {
        //
    }
}
