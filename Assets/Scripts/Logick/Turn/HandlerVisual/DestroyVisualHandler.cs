using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class DestroyVisualHandler : BaseHandler<DestroyEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public DestroyVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            _visualTurnAdapter.AddTask(new DestroyVisualTask(evt.Entity));
        }
    }
}
