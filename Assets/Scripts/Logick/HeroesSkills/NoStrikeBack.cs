using Logick.Events;

namespace Logick.HeroesSkills
{
    public sealed class NoStrikeBack : BaseSkills
    {
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            eventBus.RaiseEvent(new DisableStrikeBackEvent(attackedEntity.Value));
        }
    }
}
