
namespace Logick.Events
{
    public readonly struct SkipTurnEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;

        public SkipTurnEvent(EntityConfig targetEntity)
        {
            TargetEntity = targetEntity;
        }
    }
}
