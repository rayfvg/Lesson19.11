using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gameplay : IGame, IDataReader<PlayerData>, IDataWriter<PlayerData>
{
    private List<char> _chars; 

    private DIContainer _container;
    private ConfigsProviderService _configProviderService;

    private List<char> _randomChars = new List<char>();
    private List<char> _userInput = new List<char>();

    private int _difficulty = 3;

    private bool _inputAccept;
    private bool _itsWinner = true;
    private bool _isWorking = true;

    public Gameplay(DIContainer container, List<char> chars)
    {
        _container = container;
        _chars = chars;
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
        ISaveLoadSerivce saveLoadServise = _container.Resolve<ISaveLoadSerivce>();
        WalletService wallet = _container.Resolve<WalletService>();
        _configProviderService = _container.Resolve<ConfigsProviderService>();

        for (int i = 0; i < _userInput.Count; i++)
        {
            if (i >= _userInput.Count || _randomChars[i] != _userInput[i])
            {
                _itsWinner = false;

                wallet.Add(CurrencyTypes.Gold, _configProviderService.ValueOfMoney.ValueMoneyForLose);
                _container.Resolve<PlayerDataProvider>().Save();

                Debug.Log("Ошибка! Последовательность введена неверно.");


                if (saveLoadServise.TryLoad(out PlayerData playerData))
                {
                    playerData.CountLose++;

                    saveLoadServise.Save(playerData);
                }
                

                _isWorking = false;
                break;
            }
        }
        if (_itsWinner == true)
        {
            Debug.Log("Успех! Последовательность введена правильно.");

            wallet.Add(CurrencyTypes.Gold, _configProviderService.ValueOfMoney.ValueMoneyForWin);
            _container.Resolve<PlayerDataProvider>().Save();

            if (saveLoadServise.TryLoad(out PlayerData playerData))
            {
                playerData.CountWin++;

                saveLoadServise.Save(playerData);
            }

           

            _isWorking = false;
        } 
    }

    private void SwitchScene()
    {
        int sceneId = PlayerPrefs.GetInt("SceneId");
        if (_isWorking == false)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (_itsWinner)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new MainMenuInputArgs()));
                if (!_itsWinner)
                    _container.Resolve<SceneSwitcher>().ProcessSwitchSceneFor(new OutputGameplayArgs(new GameplayInputArgs(sceneId)));
            }
        }
    }

    public void ReadFrom(PlayerData data)
    {
        throw new System.NotImplementedException();
    }

    public void WriteTo(PlayerData data)
    {
        throw new System.NotImplementedException();
    }
}