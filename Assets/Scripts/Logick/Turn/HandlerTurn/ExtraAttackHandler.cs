using Logick.Events;
using UnityEngine;

namespace Logick.Handlers.Turn
{
    public sealed class ExtraAttackHandler : BaseHandler<ExtraAttackEvent>
    {
        public ExtraAttackHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(ExtraAttackEvent evt)
        {
            EventBus.RaiseEvent(new DealDamageEvent(evt.TargetEntity, evt.Damage));
        }
    }
}
