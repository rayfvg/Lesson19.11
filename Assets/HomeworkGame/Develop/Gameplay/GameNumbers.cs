using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNumbers : IGame
{
    private int _difficulty = 3;

    private DIContainer _container;

    private List<int> _randomNumbers = new List<int>();
    private List<int> _userInputs = new List<int>();

    private bool _working = true;

    private bool _inputAccept;

    private bool _itsWinner;

    public GameNumbers(DIContainer container)
    {
        _container = container;
    }

    public void Update()
    {
        UserInput();

        SwitchScene();
    }

    public IEnumerator ProcessGeneration()
    {
        for (int i = 0; i < _difficulty; i++)
        {
            int num = RandomNumber();
            Debug.Log(num);
            _randomNumbers.Add(num);

            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Введите последовательность");
        _inputAccept = true;
    }

    private int RandomNumber()
    {
        int number = Random.Range(0, 9);
        return number;
    }

    private void UserInput()
    {
        if (_working && _inputAccept)
        {
            for (int key = 0; key < 9; key++)
            {
                if (Input.GetKeyDown(key.ToString()))
                {
                    _userInputs.Add(key);

                    ConditionOfVictory();
                }
            }
        }
    }

    private void ConditionOfVictory()
    {
        if (_userInputs.Count == _randomNumbers.Count)
        {
            for (int i = 0; i < _randomNumbers.Count; i++)
            {
                if (_userInputs[i] != _randomNumbers[i])
                {
                    Debug.Log("Неправильная последовательность! Вы проиграли.");
                    _itsWinner = false;
                    _working = false;
                    return;
                }
            }

            Debug.Log("Вы правильно ввели последовательность! Победа!");
            _itsWinner = true;
            _working = false;
        }
    }

    private void SwitchScene()
    {
        if (_working == false)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (_itsWinner)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
                if (!_itsWinner)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new GameplayInputArgs(1)));
            }
        }
    }
}