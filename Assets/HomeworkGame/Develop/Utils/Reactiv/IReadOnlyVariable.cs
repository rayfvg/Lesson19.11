using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReadOnlyVariable<T>
{
    event Action<T, T> Changed;

    T Value { get; }
}
