using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
   public IEnumerator Run(DIContainer container)
    {
        ILoadingCurtain loadingCurtain = container.Resolve<ILoadingCurtain>();
        SceneSwitcher sceneSwitcher = container.Resolve<SceneSwitcher>();

        loadingCurtain.Show();

        Debug.Log("�������������");
        container.Resolve<PlayerDataProvider>().Load();
        container.Resolve<ConfigsProviderService>().LoadAll();

        yield return new WaitForSeconds(1.5f);

       loadingCurtain.Hide();

        sceneSwitcher.ProcessSwitchSceneFor(new OutpurBootstrapArgs(new MainMenuInputArgs()));
    }
}
