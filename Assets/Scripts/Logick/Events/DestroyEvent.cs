namespace Logick.Events
{
    public readonly struct DestroyEvent : IEvent
    {
        public readonly EntityConfig Entity;

        public DestroyEvent(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}