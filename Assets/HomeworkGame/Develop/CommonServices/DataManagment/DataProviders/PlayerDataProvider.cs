using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataProvider : DataProvider<PlayerData>
{
    private ConfigsProviderService _configsProviderService;
    private DIContainer _conteiner;

    public PlayerDataProvider(
           ISaveLoadSerivce saveLoadService,
           ConfigsProviderService configsProviderService,
           DIContainer conteiner) : base(saveLoadService)
    {
        _configsProviderService = configsProviderService;
        _conteiner = conteiner;
    }

    protected override PlayerData GetOriginData()
    {
        return new PlayerData()
        {
            WalletData = InitWalletData(),
            CountLose = 0,
            CountWin = 0
        };
    }

    private Dictionary<CurrencyTypes, int> InitWalletData()
    {
        Dictionary<CurrencyTypes, int> walletData = new();
        _configsProviderService = _conteiner.Resolve<ConfigsProviderService>();

        foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
            walletData.Add(currencyType, 0); // _configsProviderService.ValueOfMoney.GetStartValueFor(currencyType));

        return walletData;
    }
}
