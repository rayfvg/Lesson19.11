using System;
using System.ComponentModel;
using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Bootstrap _gameBootstrap;

    private void Awake()
    {
        SetupAppSettings();

        DIContainer projectConteiner = new DIContainer();

        //Регистрация сервисов на весь проект
        //Аналог global context 
        //Самый родительский контейнер для всех будущих

        RegisterResourcesAssetLoader(projectConteiner);
        RegisterCoroutinePerfarmer(projectConteiner);

        RegisterLoadingCurtain(projectConteiner);
        RegisterSceneLoader(projectConteiner);
        RegisterSceneSwitcher(projectConteiner);

        RegisterSaveLoadService(projectConteiner);
        RegisterPlayerDataProveder(projectConteiner);

        RegisterWalletService(projectConteiner);

        RegisterUserInput(projectConteiner);
        RegisterSceneSelection(projectConteiner);

        RegisterConfigsProviderService(projectConteiner);

        RegisterGameCounterService(projectConteiner);

        projectConteiner.Initialize();

        projectConteiner.Resolve<ICoroutinePerformer>().StartRefrorm(_gameBootstrap.Run(projectConteiner));
    }


    private void SetupAppSettings()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
    }

    private void RegisterGameCounterService(DIContainer container)
        => container.RegisterAsSingle(c => new GameCounterService(c.Resolve<PlayerDataProvider>(), c)).NonLazy();
  
    private void RegisterWalletService(DIContainer container)
        => container.RegisterAsSingle(c => new WalletService(c.Resolve<PlayerDataProvider>())).NonLazy();


    private void RegisterPlayerDataProveder(DIContainer container)
        => container.RegisterAsSingle(c => new PlayerDataProvider(c.Resolve<ISaveLoadSerivce>(), c.Resolve<ConfigsProviderService>(), container)).NonLazy();

    private void RegisterSaveLoadService(DIContainer container)
        => container.RegisterAsSingle<ISaveLoadSerivce>(c => new SaveLoadService(new JsonSerializer(), new LocalDataRepository()));


    private void RegisterConfigsProviderService(DIContainer container)
        => container.RegisterAsSingle(c => new ConfigsProviderService(c.Resolve<ResourcesAssetsLoader>())).NonLazy();


    private void RegisterUserInput(DIContainer container)
        => container.RegisterAsSingle(c => new UserInput());

    private void RegisterSceneSelection(DIContainer container)
        => container.RegisterAsSingle(c => new SceneSelection(container));


    private void RegisterResourcesAssetLoader(DIContainer container)
            => container.RegisterAsSingle(c => new ResourcesAssetsLoader());

    private void RegisterCoroutinePerfarmer(DIContainer container)
    {
        container.RegisterAsSingle<ICoroutinePerformer>(c =>
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();
            CoroutinePerformer coroutinePerformerPrefab = resourcesAssetsLoader
            .LoadResource<CoroutinePerformer>(InfrastuctureAssetPaths.CoroutinePerformerPath);

            return Instantiate(coroutinePerformerPrefab);
        });
    }

    private void RegisterLoadingCurtain(DIContainer container)
    {
        container.RegisterAsSingle<ILoadingCurtain>(c =>
        {
            ResourcesAssetsLoader resourcesAssetsLoader = c.Resolve<ResourcesAssetsLoader>();
            StandartLoadingCurtain standartLoadingCurtainPrefab = resourcesAssetsLoader
            .LoadResource<StandartLoadingCurtain>(InfrastuctureAssetPaths.LoadingCurtainPath);

            return Instantiate(standartLoadingCurtainPrefab);
        });
    }


    private void RegisterSceneLoader(DIContainer container)
   => container.RegisterAsSingle<ISceneLoader>(c => new DefaultSceneLoader());


    private void RegisterSceneSwitcher(DIContainer container)
    => container.RegisterAsSingle(c
        => new SceneSwitcher(
            c.Resolve<ICoroutinePerformer>(),
            c.Resolve<ILoadingCurtain>(),
            c.Resolve<ISceneLoader>(),
            c));
}
