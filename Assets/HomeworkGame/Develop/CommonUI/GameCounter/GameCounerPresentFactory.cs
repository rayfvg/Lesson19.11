using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCounerPresentFactory
{
    private GameCounterService _gameCounterService;
    private DIContainer _container;

    public GameCounerPresentFactory(DIContainer container)
    {
        _gameCounterService = container.Resolve<GameCounterService>();
        _container = container;
    }

    public GameCounerWinnerPresenter CreateGameWinnerCounterPresent(TextWithValue textView) =>
        new GameCounerWinnerPresenter(_gameCounterService, textView, _container);

    public GameCounterLosePresenter CreateLoseCounterPresent(TextWithValue textView) =>
       new GameCounterLosePresenter(_gameCounterService, textView, _container);
}
