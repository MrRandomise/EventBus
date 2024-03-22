using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class AttackVisualHandler : BaseHandler<AttackEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public AttackVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(AttackEvent evt)
        {
            _visualTurnAdapter.AddTask(new AttackVisualTask(evt.Entity, evt.Target));
        }
    }
}
