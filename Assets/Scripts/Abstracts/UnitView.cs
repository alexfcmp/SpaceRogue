using System;
using Gameplay.Damage;
using Gameplay.Health;
using UnityEngine;

namespace Abstracts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class UnitView : MonoBehaviour, IDamageableView
    {
        [field: SerializeField] public UnitType UnitType { get; private set; }
        
        public event Action<DamageModel> DamageTaken = (DamageModel _) => { };

        public void OnTriggerEnter2D(Collider2D other)
        {   
            CollisionEnter(other.gameObject);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionEnter(collision.gameObject);
        }

        public void TakeDamage(IDamagingView damageComponent)
        {
            DamageTaken(damageComponent.DamageModel);
        }

        private void CollisionEnter(GameObject go)
        {
            var damageComponent = go.GetComponent<IDamagingView>();
            if (damageComponent is not null)
            {
                TakeDamage(damageComponent);
            }
        }
    }
}