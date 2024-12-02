using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/NewStartGameConfig", fileName = "StartGameConfig")]
public class StartGameSettings : ScriptableObject
{
    [SerializeField] private List<CurrencyConfig> _mode;

    public List<char> GetLatters(GameModes mode) => _mode.First(config => config.GameModes == mode).Chars;

    [Serializable]
    private class CurrencyConfig
    {
        [field: SerializeField] public GameModes GameModes { get; private set; }

        [field: SerializeField] public List<char> Chars { get; private set; }
    }
}
