using Logick.Events;

namespace Logick.Turn.Tasks
{
    public sealed class StrikeTask : TurnTask
    {
        private readonly EventBus _eventBus;
        private readonly CurrentEntity _currentEntity;
        private readonly AttackedEntity _attackedEntity;
        
        public StrikeTask(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity)
        {
            _eventBus = eventBus;
            _currentEntity = currentEntity;
            _attackedEntity = attackedEntity;
        }

        protected override void OnRun()
        {
            if (!_attackedEntity.Value.IsDead)
            {
                if (!_attackedEntity.Value.CantStrikeBack)
                {
                    _eventBus.RaiseEvent(new AttackEvent(_attackedEntity.Value, _currentEntity.Value));    
                }
                else
                {
                    _attackedEntity.Value.CantStrikeBack = false;
                }
            }
            Finish();
        }
    }
}
