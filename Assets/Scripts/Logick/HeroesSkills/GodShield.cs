using Logick.Events;

namespace Logick.HeroesSkills
{
    public sealed class GodShield : BaseSkills
    {
        private bool _isUsed;
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            if(_isUsed) return;
            eventBus.RaiseEvent(new HealEvent(attackedEntity.Value, currentEntity.Value.Damage));
            _isUsed = true;
        }
    }
}
