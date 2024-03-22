using Logick.Events;

namespace Logick.Turn.Tasks
{
    public sealed class AfterStrikeSkillsTask : TurnTask
    {
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;
        private readonly EntityStorage _entityStorage;
        private readonly EventBus _eventBus;

        public AfterStrikeSkillsTask(CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage, EventBus eventBus)
        {
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
            _entityStorage = entityStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_attackedEntity.Value.TryGetAfterStrikeSkills(out var ability))
            {
                _eventBus.RaiseEvent(new AbilityUsedEvent(_currentEntity.Value));
                ability.Run(_eventBus, _currentEntity, _attackedEntity, _entityStorage);
            }
            Finish();
        }
    }
}
