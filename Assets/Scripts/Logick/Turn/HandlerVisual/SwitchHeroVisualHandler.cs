using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class SwitchHeroVisualHandler : BaseHandler<SwitchHeroEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public SwitchHeroVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(SwitchHeroEvent evt)
        {
            _visualTurnAdapter.AddTask(new SwitchHeroVisualTask(evt.Entity));
        }
    }
}
