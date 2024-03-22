using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;
using JetBrains.Annotations;

namespace Logick.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class HealVisualHandler : BaseHandler<HealEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public HealVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(HealEvent evt)
        {
            _visualTurnAdapter.AddTask(new HealVisualTask(evt.TargetEntity));
        }
    }
}
