using Logick.Events;

namespace Logick.HeroesSkills
{
    public sealed class FrozeEnemy : BaseSkills
    {
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            eventBus.RaiseEvent(new SkipTurnEvent(attackedEntity.Value));
        }
    }
}
