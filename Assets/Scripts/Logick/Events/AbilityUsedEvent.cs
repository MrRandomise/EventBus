
namespace Logick.Events
{
    public readonly struct AbilityUsedEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;

        public AbilityUsedEvent(EntityConfig targetEntity)
        {
            TargetEntity = targetEntity;
        }
    }
}
