namespace Logick.Events
{
    public readonly struct DisableStrikeBackEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;

        public DisableStrikeBackEvent(EntityConfig targetEntity)
        {
            TargetEntity = targetEntity;
        }
    }
}
