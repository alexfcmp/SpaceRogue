using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(fileName = nameof(BackgroundConfig), menuName = "Configs/Background/" + nameof(BackgroundConfig))]
    public sealed class BackgroundConfig : ScriptableObject
    {
        [field: SerializeField] public float BackCoefficient { get; private set; }
        [field: SerializeField] public float MidCoefficient { get; private set; }
        [field: SerializeField] public float ForeCoefficient { get; private set; }

        [field: SerializeField] public float NebulaBackCoefficient { get; private set; }
        [field: SerializeField] public float NebulaForeCoefficient { get; private set; }
    }
}