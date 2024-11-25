using System.Collections;
using UnityEngine;

public enum GameModes
{
    Numbers = 1,
    Letters = 2
}

public class GameplayBootstrap : MonoBehaviour
{
    private DIContainer _container;

    private IGame _game;

    private bool _initializedComplited;
    public IEnumerator Run(DIContainer container, GameplayInputArgs gameplayInputArgs)
    {
        _container = container;

       
        if (gameplayInputArgs.LevelNumber == (int)GameModes.Numbers)
            StartGameNumbers();
        if (gameplayInputArgs.LevelNumber == (int)GameModes.Letters)
            StartGameLetters();

        yield return new WaitForSeconds(1);

        _initializedComplited = true;
    }

    private void StartGameNumbers()
    {
        GameNumbers gameNumbers = new GameNumbers(_container);
        _game = gameNumbers;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(gameNumbers.ProcessGeneration());
    }

    private void StartGameLetters()
    {
        GameLetters gameLetters = new GameLetters(_container);
        _game = gameLetters;
        _container.Resolve<ICoroutinePerformer>().StartRefrorm(gameLetters.ProcessGeneration());
    }

    private void Update()
    {
        if (_initializedComplited)
        {
            _game.Update();
        }
    }
}
