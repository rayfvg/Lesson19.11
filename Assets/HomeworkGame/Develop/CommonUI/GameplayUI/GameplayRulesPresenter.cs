using System;
using UnityEngine;

public class GameplayRulesPresenter 
{
   private ConfigsProviderService _configProviderService;
    private TextWithValue _view;
    private Gameplay _gameplayLatters;
    private Gameplay _gameplayNumbers;
    private string _collectedChars;

    public GameplayRulesPresenter(ConfigsProviderService configProviderService, TextWithValue textValue, DIContainer conteiner, Gameplay gameplay, Gameplay latters)
    {
        _configProviderService = configProviderService;
        _view = textValue;
        _gameplayLatters = latters;
        _gameplayNumbers = gameplay;
        _collectedChars = string.Empty;
    }

    public void Initialize()
    {
        _view.SetText("���������: ");

        _gameplayNumbers.CharsAdded += OnCharChanged;
        _gameplayLatters.CharsAdded += OnCharChanged;
    }

    private void OnCharChanged(char newChar)
    {
        _collectedChars += newChar; // ��������� ����� ������ � ������
        UpdateValue(_collectedChars); // ��������� ����������� ���� ������
    }

    public void Dispose()
    {
        _gameplayNumbers.CharsAdded -= OnCharChanged;
        _gameplayLatters.CharsAdded -= OnCharChanged;
    }

    private void UpdateValue(string value)
    {
        _view.SetValue(value); // ������������� ������ � �������������
    }
}
