using Logick.Events;

namespace Logick.Turn.Tasks
{
    public sealed class AfterAttackSkillsTask : TurnTask
    {
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;
        private readonly EntityStorage _entityStorage;
        private readonly EventBus _eventBus;

        public AfterAttackSkillsTask(CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage, EventBus eventBus)
        {
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
            _entityStorage = entityStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_currentEntity.Value.TryGetAfterAttackAbility(out var ability))
            {
                _eventBus.RaiseEvent(new AbilityUsedEvent(_currentEntity.Value));
                ability.Run(_eventBus, _currentEntity, _attackedEntity, _entityStorage);
            }
            Finish();
        }
    }
}
