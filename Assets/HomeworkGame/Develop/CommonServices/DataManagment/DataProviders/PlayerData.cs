using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData : ISaveData
{
    public Dictionary<CurrencyTypes, int> WalletData;
    public int CountWin;
    public int CountLose;
}