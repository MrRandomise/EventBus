using Logick.Events;
using Logick.Handlers.Turn;

namespace Logick.Handlers.Visual
{
    public sealed class StartTurnVisualHandler : BaseHandler<StartTurnEvent>
    {
        public StartTurnVisualHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(StartTurnEvent evt)
        {
            
        }
    }
}
