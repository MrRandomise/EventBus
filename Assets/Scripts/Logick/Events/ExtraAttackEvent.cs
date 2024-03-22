
namespace Logick.Events
{
    public readonly struct ExtraAttackEvent : IEvent
    {
        public readonly EntityConfig SourceEntity;
        public readonly EntityConfig TargetEntity;
        public readonly int Damage;

        public ExtraAttackEvent(EntityConfig currentEntity, EntityConfig targetEntity, int damage)
        {
            SourceEntity = currentEntity;
            TargetEntity = targetEntity;
            Damage = damage;
        }
    }
}
