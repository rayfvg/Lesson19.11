using System;
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

        RegisterUserInput(projectConteiner);
        RegisterSceneSelection(projectConteiner);

        projectConteiner.Resolve<ICoroutinePerformer>().StartRefrorm(_gameBootstrap.Run(projectConteiner));
    }

    

    private void SetupAppSettings()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
    }

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
