namespace Logick.Events
{
    public readonly struct DealDamageEvent : IEvent
    {
        public readonly EntityConfig Entity;
        public readonly int Damage;

        public DealDamageEvent(EntityConfig entity, int damage)
        {
            Entity = entity;
            Damage = damage;
        }
    }
}