using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    //если ентри поинт это просто гробольные регистрации для старта проекта, то ботстрап, уже инит начала работы
   public IEnumerator Run(DIContainer container)
    {
        ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();
        SceneSwitcher sceneSwitcher = container.Resolve<SceneSwitcher>();

        loadingCurtain.Show();

        Debug.Log("Инициализация");

        yield return new WaitForSeconds(1.5f);

       loadingCurtain.Hide();

        sceneSwitcher.ProcessSwitchSceneFor(new OutpurBootstrapArgs(new MainMenuInputArgs()));
    }
}
