using Abstracts;

namespace Gameplay.Damage
{
    public sealed class DamageModel
    {
        public float DamageAmount { get; }
        public UnitType UnitType { get; }

        public DamageModel(float damageAmount)
        {
            DamageAmount = damageAmount;
            UnitType = UnitType.None;
        }

        public DamageModel(float damageAmount, UnitType unitType)
        {
            DamageAmount = damageAmount;
            UnitType = unitType;
        }
    }
}