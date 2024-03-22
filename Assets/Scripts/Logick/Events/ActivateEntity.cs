
namespace Logick.Events
{
    public readonly struct ActivateEntity : IEvent
    {
        public readonly EntityConfig Entity;

        public ActivateEntity(EntityConfig entity)
        {
            Entity = entity;
        }
    }
}
