using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class ExtraAttackVisualHandler : BaseHandler<ExtraAttackEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public ExtraAttackVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(ExtraAttackEvent evt)
        {
            _visualTurnAdapter.AddTask(new AttackVisualTask(evt.SourceEntity, evt.TargetEntity));
        }
    }
}
