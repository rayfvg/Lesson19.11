
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Configs/ValueOfMoney", fileName = "ValueOfMoney")]
public class ValueOfMoney : ScriptableObject
{
    [SerializeField] private List<CurrencyConfig> _values;

    public int GetStartValueFor(CurrencyTypes currencyType) => _values.First(config => config.Type == currencyType).Value;
    public int ValueMoneyForWin;
    public int ValueMoneyForLose;

    [Serializable]
    private class CurrencyConfig
    {
        [field: SerializeField] public CurrencyTypes Type { get; private set; }
        [field: SerializeField] public int Value { get; private set; }
    }
}