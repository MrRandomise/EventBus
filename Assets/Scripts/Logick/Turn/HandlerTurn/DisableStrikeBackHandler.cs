using Logick.Events;

namespace Logick.Handlers.Turn
{
    public sealed class DisableStrikeBackHandler : BaseHandler<DisableStrikeBackEvent>
    {
        public DisableStrikeBackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DisableStrikeBackEvent evt)
        {
            evt.TargetEntity.CantStrikeBack = true;
        }
    }
}
