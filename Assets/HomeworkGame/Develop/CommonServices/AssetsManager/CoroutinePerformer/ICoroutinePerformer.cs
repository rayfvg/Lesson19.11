using System.Collections;
using UnityEngine;

public interface ICoroutinePerformer
{
    Coroutine StartRefrorm(IEnumerator coroutineFunction);
    void StopPerform(Coroutine coroutine);
}