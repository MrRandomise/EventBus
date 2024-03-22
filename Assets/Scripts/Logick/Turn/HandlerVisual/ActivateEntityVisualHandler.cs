using Logick.Events;
using Logick.Handlers.Turn;
using Logick.Turn.Visual;
using Logick.Visual.Tasks;

namespace Logick.Handlers.Visual
{
    public sealed class ActivateEntityVisualHandler : BaseHandler<ActivateEntity>
    {
        private readonly VisualTurnAdapter _visualTurnAdapter;
        
        public ActivateEntityVisualHandler(EventBus eventBus, VisualTurnAdapter visualTurnAdapter) : base(eventBus)
        {
            _visualTurnAdapter = visualTurnAdapter;
        }

        protected override void HandleEvent(ActivateEntity evt)
        {
            _visualTurnAdapter.AddTask(new ActivateEntityVisualTask(evt.Entity));
        }
    }
}
