using Logick.Events;
using UnityEngine;

namespace Logick.Handlers.Turn
{
    public sealed class AttackHandler : BaseHandler<AttackEvent>
    {
        public AttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(AttackEvent evt)
        {
            EventBus.RaiseEvent(new DealDamageEvent(evt.Target, evt.Entity.Damage));
        }
    }
}
