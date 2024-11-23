using UnityEngine;

public class ResourcesAssetsLoader
{
   public T LoadResource<T>(string resourcePath) where T : Object
        => Resources.Load<T>(resourcePath);
}
