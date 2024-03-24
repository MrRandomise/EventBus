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
                UseGlobalSkills(entity);
            }

            Finish();
        }

        private void UseGlobalSkills(EntityConfig entity)
        {
            if (entity.TryGetGlobalSkills(out var skills))
            {
                _eventBus.RaiseEvent(new SkillsUsedEvent(entity));
                var tempCurrentEntity = new CurrentEntity() {Value = entity};
                skills.Run(_eventBus, tempCurrentEntity, _attackedEntity, _entityStorage);
            }
        }
    }
}
