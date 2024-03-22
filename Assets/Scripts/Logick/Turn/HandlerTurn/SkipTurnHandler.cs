using Logick.Events;

namespace Logick.Handlers.Turn
{
    public sealed class SkipTurnHandler : BaseHandler<SkipTurnEvent>
    {
        public SkipTurnHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(SkipTurnEvent evt)
        {
            evt.TargetEntity.SkipTurn = true;
        }
    }
}
