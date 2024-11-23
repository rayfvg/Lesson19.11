using System.Collections;
using UnityEngine;

public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
{

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public Coroutine StartRefrorm(IEnumerator coroutineFunction)
        => StartCoroutine(coroutineFunction);


    public void StopPerform(Coroutine coroutine)
       => StopCoroutine(coroutine);
}