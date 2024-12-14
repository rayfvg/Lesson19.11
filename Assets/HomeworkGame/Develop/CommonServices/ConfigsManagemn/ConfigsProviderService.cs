using UnityEngine;

public class ConfigsProviderService
{
  private ResourcesAssetsLoader _resourcesAssetsLoader;

    public ConfigsProviderService(ResourcesAssetsLoader resourcesAssetsLoader)
    {
        _resourcesAssetsLoader = resourcesAssetsLoader;
    }

    public StartGameSettings StartGameSettings { get; private set; }
    public ValueOfMoney ValueOfMoney { get; private set; }

    public CurrencyIconsConfig CurrencyIconsConfig { get; private set; }

    public void LoadAll()
    {
        LoadStartGameSetting();
        LoadValueOfMoney();
        LoadCurrencyIconsConfig();
    }

    private void LoadStartGameSetting()
   => StartGameSettings = _resourcesAssetsLoader.LoadResource<StartGameSettings>("Configs/StartGameConfig");

    private void LoadValueOfMoney()
        => ValueOfMoney = _resourcesAssetsLoader.LoadResource<ValueOfMoney>("Configs/ValueOfMoney");

    private void LoadCurrencyIconsConfig()
       => CurrencyIconsConfig = _resourcesAssetsLoader.LoadResource<CurrencyIconsConfig>("Configs/CurrencyIconsConfig");
}