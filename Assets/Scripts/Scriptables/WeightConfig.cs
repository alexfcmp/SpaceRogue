using System;
using UnityEngine;

namespace Scriptables
{
    [Serializable]
    public sealed class WeightConfig<T>
    {
        [field: SerializeField, Min(0)] public int Weight { get; private set; }
        [field: SerializeField] public T Config { get; private set; }
    }
}