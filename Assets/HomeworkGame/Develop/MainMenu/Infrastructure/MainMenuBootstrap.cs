using System.Collections;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootstrap : MonoBehaviour, IDataReader<PlayerData>, IDataWriter<PlayerData>
{
    private DIContainer _container;
    private SceneSelection _sceneSelection;
    private CurrencyPresenter _currencyPresenter;
    private GameCounerWinnerPresenter _gameCounerWinnerPresenter;
    private GameCounterLosePresenter _gameCounterLosePresenter;

    private bool _isInitialized = false;

    public IEnumerator Run(DIContainer container, MainMenuInputArgs maimMenuInputArgs)
    {
        _container = container;

        ProcessRegisrations();

        yield return new WaitForSeconds(1);
    }

    private void Update() //imSorry(
    {
        if (_isInitialized == false)
            return;

        _sceneSelection.Update();
    }

    private void ProcessRegisrations()
    {
        _container.RegisterAsSingle(c => new WalletPresenterFactory(c)).NonLazy();
        _container.RegisterAsSingle(c => new GameCounerPresentFactory(c)).NonLazy();

        _container.RegisterAsSingle(c =>
        {
            MainMenuUIRoot maimMenuUIRoot = c.Resolve<ResourcesAssetsLoader>().LoadResource<MainMenuUIRoot>("MainMenu/UI/MaimMenuUItRoot");
            return Instantiate(maimMenuUIRoot);
        }).NonLazy();

        MainMenuUIRoot mainMenuUIRoot = _container.Resolve<MainMenuUIRoot>();
        _currencyPresenter = _container.Resolve<WalletPresenterFactory>().CreateCurrencyPresenter(mainMenuUIRoot._currencyView, CurrencyTypes.Gold);
        _gameCounerWinnerPresenter = _container.Resolve<GameCounerPresentFactory>().CreateGameWinnerCounterPresent(mainMenuUIRoot._counterWinView);
        _gameCounterLosePresenter = _container.Resolve<GameCounerPresentFactory>().CreateLoseCounterPresent(mainMenuUIRoot._counterLoseView);

        _sceneSelection = _container.Resolve<SceneSelection>();
        _isInitialized = true;

        _container.Initialize();
        _currencyPresenter.Initialize();
        _gameCounerWinnerPresenter.Initialize();
        _gameCounterLosePresenter.Initialize();

        mainMenuUIRoot._deleteSaveButton.onClick.AddListener(DeleteAllSave);
    }

    private void DeleteAllSave()
    {
        PlayerDataProvider data =  _container.Resolve<PlayerDataProvider>();
        data.Reset();
       
        Debug.Log("Клик");
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
