namespace Logick.Events
{
    public readonly struct SwitchHeroEvent : IEvent
    {
        public readonly EntityConfig Entity;

        public SwitchHeroEvent(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
