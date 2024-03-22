using Logick.Events;

namespace Logick.Handlers.Turn
{
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        public DestroyHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            evt.Entity.IsDead = true;
        }
    }
}
