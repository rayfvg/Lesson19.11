
public class GameCounerWinnerPresenter
{
   private GameCounterService _gameCounterService;

    private TextWithValue _view;

    public GameCounerWinnerPresenter(GameCounterService gameCounterService, TextWithValue textValue, DIContainer conteiner)
    {
        _gameCounterService = gameCounterService;
        _view = textValue;
    }

    public void Initialize()
    {
        _view.SetText("Количество побед");
        _view.SetValue(_gameCounterService.WinnerCount.ToString());
    }

    public void Dispose()
    {
        //
    }
}
