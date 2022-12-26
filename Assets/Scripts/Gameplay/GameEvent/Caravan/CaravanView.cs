using Abstracts;
using Gameplay.Damage;
using UnityEngine;

namespace Gameplay.GameEvent
{
    [RequireComponent(typeof(BoxCollider2D))]
    public sealed class CaravanView : UnitView, IDamagingView
    {
        public bool IsLastDamageFromPlayer { get; private set; }
        public DamageModel DamageModel { get; private set; }

        public void Init(DamageModel damageModel)
        {
            DamageModel = damageModel;
        }

        private new void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);

            if(collision.TryGetComponent(out IDamagingView damagingView))
            {
                if(damagingView.DamageModel.UnitType == UnitType.Player)
                {
                    IsLastDamageFromPlayer = true;
                }
            }
            else
            {
                IsLastDamageFromPlayer = false;
            }
        }
    }
}