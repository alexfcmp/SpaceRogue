using Abstracts;
using System;
using UnityEngine;

namespace Gameplay.Space.Obstacle
{
    [RequireComponent(typeof(Collider2D))]
    public sealed class ObstacleView : MonoBehaviour
    {
        public event Action<UnitView> OnTriggerEnter = (UnitView _) => {};
        public event Action<UnitView> OnTriggerStay = (UnitView _) => { };
        public event Action<UnitView> OnTriggerExit = (UnitView _) => { };

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out UnitView unitView))
            {
                OnTriggerEnter(unitView);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out UnitView unitView))
            {
                OnTriggerStay(unitView);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out UnitView unitView))
            {
                OnTriggerExit(unitView);
            }
        }
    }
}