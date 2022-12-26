using Abstracts;
using Gameplay.Damage;
using UnityEngine;

namespace Gameplay.Space.Star
{
    public sealed class StarController : BaseController
    {
        public StarView StarView { get; }

        private const int FatalDamage = 9999;

        public StarController(StarView starView, Transform starsParent)
        {
            StarView = starView;
            StarView.transform.parent = starsParent;

            var damageModel = new DamageModel(FatalDamage);
            starView.Init(damageModel);

            AddGameObject(starView.gameObject);
        }

    }
}