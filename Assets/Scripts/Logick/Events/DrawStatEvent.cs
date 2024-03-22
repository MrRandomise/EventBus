namespace Logick.Events
{
    public readonly struct DrawStatEvent : IEvent
    {
        public readonly EntityConfig Entity;

        public DrawStatEvent(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
