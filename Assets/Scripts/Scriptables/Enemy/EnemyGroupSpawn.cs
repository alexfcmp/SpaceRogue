using System;
using UnityEngine;

namespace Scriptables.Enemy
{
    [Serializable]
    public sealed class EnemyGroupSpawn
    {
        [field: SerializeField, Min(1)] public int GroupCount { get; private set; }
    }
}