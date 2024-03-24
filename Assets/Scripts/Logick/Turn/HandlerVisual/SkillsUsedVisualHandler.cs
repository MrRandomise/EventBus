using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class SkillsUsedVisualHandler : BaseHandler<SkillsUsedEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public SkillsUsedVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(SkillsUsedEvent evt)
        {
            _visualTurnAdapter.AddTask(new SkillsUsedVisualTask(evt.TargetEntity));
        }
    }
}
