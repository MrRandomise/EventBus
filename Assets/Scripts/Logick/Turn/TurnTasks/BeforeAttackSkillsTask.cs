using Logick.Events;

namespace Logick.Turn.Tasks
{
    public sealed class BeforeAttackSkillsTask : TurnTask
    {
        
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;
        private readonly EntityStorage _entityStorage;
        private readonly EventBus _eventBus;

        public BeforeAttackSkillsTask(CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage, EventBus eventBus)
        {
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
            _entityStorage = entityStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            if (_currentEntity.Value.TryGetBeforeAttackSkills(out var skills))
            {
                _eventBus.RaiseEvent(new SkillsUsedEvent(_currentEntity.Value));
                skills.Run(_eventBus, _currentEntity, _attackedEntity, _entityStorage);
            }
            Finish();
        }
    }
}
