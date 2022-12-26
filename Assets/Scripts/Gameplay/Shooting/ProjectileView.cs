using System;
using Gameplay.Damage;
using UnityEngine;

namespace Gameplay.Shooting
{
    [RequireComponent(typeof(Collider))]
    public sealed class ProjectileView : MonoBehaviour, IDamagingView
    {
        public event Action CollisionEnter = () => { };
        public DamageModel DamageModel { get; private set; }

        public void Init(DamageModel damageModel)
        {
            DamageModel = damageModel;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            CollisionEnter();
        }
    }
}