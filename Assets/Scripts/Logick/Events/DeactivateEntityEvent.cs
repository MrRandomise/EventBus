using UnityEngine;

namespace Logick.Events
{
    public readonly struct DeactivateEntityEvent : IEvent
    {
        public readonly EntityConfig Entity;

        public DeactivateEntityEvent(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
