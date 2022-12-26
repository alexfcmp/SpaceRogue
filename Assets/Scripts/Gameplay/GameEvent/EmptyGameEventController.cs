using Gameplay.Player;
using Scriptables.GameEvent;

namespace Gameplay.GameEvent
{
    public sealed class EmptyGameEventController : GameEventController
    {
        private readonly EmptyGameEventConfig _emptyGameEventConfig;

        public EmptyGameEventController(GameEventConfig config, PlayerController playerController) : base(config, playerController)
        {
            var emptyGameEventConfig = config as EmptyGameEventConfig;
            _emptyGameEventConfig = emptyGameEventConfig
                ? emptyGameEventConfig
                : throw new System.Exception("Wrong config type was provided");
        }

        protected override bool RunGameEvent()
        {
            Debug($"EmptyGameEvent completed");
            return true;
        }
    }
}