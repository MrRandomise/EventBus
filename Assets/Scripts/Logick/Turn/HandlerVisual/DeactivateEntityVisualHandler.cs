using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class DeactivateEntityVisualHandler : BaseHandler<DeactivateEntityEvent>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;

        public DeactivateEntityVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(DeactivateEntityEvent evt)
        {
            _visualTurnAdapter.AddTask(new DeactivateEntityVisualTask(evt.Entity));
        }
    }
}
