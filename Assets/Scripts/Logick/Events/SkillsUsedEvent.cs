
namespace Logick.Events
{
    public readonly struct SkillsUsedEvent : IEvent
    {
        public readonly EntityConfig TargetEntity;

        public SkillsUsedEvent(EntityConfig targetEntity)
        {
            TargetEntity = targetEntity;
        }
    }
}
