using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLetters : IGame
{
    private List<char> _chars = new List<char> { 'a', 'b', 'c', 'd', 'f', 'q', 'w', 'e' };

    private DIContainer _container;

    private List<char> _randomChars = new List<char>();
    private List<char> _userInput = new List<char>();

    private int _difficulty = 3;

    private bool _inputAccept;
    private bool _itsWinner = true;
    private bool _isWorking = true;

    public GameLetters(DIContainer container)
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
            char letter = RandomChar();
            Debug.Log(letter);
            _randomChars.Add(letter);

            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Введите последовательность");
        _inputAccept = true;
    }

    private char RandomChar()
    {
        int randomIndex = Random.Range(0, _chars.Count);

        return _chars[randomIndex];
    }

    private void UserInput()
    {
        if (_inputAccept)
        {
            string input = Input.inputString;
            foreach (char letter in input)
            {
                _userInput.Add(letter);

                if (_userInput.Count >= _difficulty)
                {
                    _inputAccept = false;
                    ConditionOfVictory();
                }

            }
        }
    }

    private void ConditionOfVictory()
    {
        _itsWinner = true;

        for (int i = 0; i < _userInput.Count; i++)
        {
            if (i >= _userInput.Count || _randomChars[i] != _userInput[i])
            {
                _itsWinner = false;
                Debug.Log("Ошибка! Последовательность введена неверно.");
                _isWorking = false;
                break;
            }
        }
        if (_itsWinner == true)
        {
            Debug.Log("Успех! Последовательность введена правильно.");
            _isWorking = false;
        } 
    }

    private void SwitchScene()
    {
        if (_isWorking == false)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (_itsWinner)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
                if (!_itsWinner)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new GameplayInputArgs(2)));
            }
        }
    }
}