using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class AttackVisualTask : TurnTask
    {
        private readonly EntityConfig _sourceEntity;
        private readonly EntityConfig _targetEntity;

        public AttackVisualTask(EntityConfig sourceEntity, EntityConfig targetEntity)
        {
            _sourceEntity = sourceEntity;
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            var animation = _sourceEntity.View.AnimateAttack(_targetEntity.View);
            var awaiter = animation.GetAwaiter();
            awaiter.OnCompleted(Finish);
        }
    }
}
