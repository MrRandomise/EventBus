using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class DealDamageVisualHandler : BaseHandler<DealDamageEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;
        public DealDamageVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            _visualTurnAdapter.AddTask(new DealDamageVisualTask(evt.Entity));
            _visualTurnAdapter.AddTask(new DrawStatsTask(evt.Entity));
        }
    }
}
