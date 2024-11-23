using System.Collections;
using UnityEngine;

public class GameplayBootstrap : MonoBehaviour
{
    private DIContainer _container;

    private GameNumbers _gameNumbers;
    private GameLetters _gameLetters;

    private IGame _game;

    private bool _initializedComplited;
    public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
    {
        _container = container;

        ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();
        loadingCurtain.Show();

        if (gameplayInputArgs.LevelNummer == 1)
            ProcessRegisrationsGameNumbers();
        if (gameplayInputArgs.LevelNummer == 2)
            ProcessRegisrationsGameLetters();

        yield return new WaitForSeconds(1);
        loadingCurtain.Hide();

        _initializedComplited = true;
    }

    private void ProcessRegisrationsGameNumbers()
    {
        _gameNumbers = new GameNumbers(_container);
        _game = _gameNumbers;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(_gameNumbers.ProcessGeneration());
    }

    private void ProcessRegisrationsGameLetters()
    {
        _gameLetters = new GameLetters(_container);
        _game = _gameLetters;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(_gameLetters.ProcessGeneration());
    }

    private void Update()
    {
        if (_initializedComplited)
        {
            _game.Update();
        }
    }
}
