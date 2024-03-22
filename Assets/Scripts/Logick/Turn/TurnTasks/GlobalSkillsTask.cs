using Logick.Events;

namespace Logick.Turn.Tasks
{
    public sealed class GlobalSkillsTask : TurnTask
    {
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;
        private readonly EntityStorage _entityStorage;
        private readonly EventBus _eventBus;

        public GlobalSkillsTask(CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage, EventBus eventBus)
        {
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
            _entityStorage = entityStorage;
            _eventBus = eventBus;
        }

        protected override void OnRun()
        {
            var currentTeam = _entityStorage.GetTeam(_currentEntity.Value.Team);
            foreach (var entity in currentTeam)
            {
                if(entity.IsDead) continue;
                UseGlobalAbility(entity);
            }

            Finish();
        }

        private void UseGlobalAbility(EntityConfig entity)
        {
            if (entity.TryGetGlobalAbility(out var ability))
            {
                _eventBus.RaiseEvent(new AbilityUsedEvent(entity));
                var tempCurrentEntity = new CurrentEntity() {Value = entity};
                ability.Run(_eventBus, tempCurrentEntity, _attackedEntity, _entityStorage);
            }
        }
    }
}
