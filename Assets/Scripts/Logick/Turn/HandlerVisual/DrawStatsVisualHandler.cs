using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class DrawStatsVisualHandler : BaseHandler<DrawStatEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public DrawStatsVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(DrawStatEvent evt)
        {
            _visualTurnAdapter.AddTask(new DrawStatsTask(evt.Entity));
        }
    }
}
