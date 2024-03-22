namespace Logick.Events
{
    public readonly struct HealEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;
        public readonly int HealAmount;

        public HealEvent(EntityConfig targetEntity, int healAmount)
        {
            TargetEntity = targetEntity;
            HealAmount = healAmount;
        }
    }
}
