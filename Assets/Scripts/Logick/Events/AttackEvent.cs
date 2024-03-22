namespace Logick.Events
{
    public readonly struct AttackEvent : IEvent
    {
        public readonly EntityConfig Entity;
        public readonly EntityConfig Target;

        public AttackEvent(EntityConfig entity, EntityConfig target)
        {
            Entity = entity;
            Target = target;
        }
    }
}
