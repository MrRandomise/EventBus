using Logick.Events;
using UnityEngine;

namespace Logick.Handlers.Turn
{
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            Debug.Log($"���� �������� �����: {evt.Entity.Name}, {evt.Damage}");
            evt.Entity.CurrentHealth -= evt.Damage;
            if (evt.Entity.CurrentHealth <= 0)
            {
                EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }
            Debug.Log($"���� �������� �����: {evt.Entity.Name}, ������: {evt.Entity.CurrentHealth}/{evt.Entity.Health}");
        }
    }
}
