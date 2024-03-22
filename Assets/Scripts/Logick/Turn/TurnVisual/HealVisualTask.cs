using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class HealVisualTask : TurnTask
    {
        private readonly EntityConfig _targetEntity;

        public HealVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            _targetEntity.View.Heal();
            Finish();
        }
    }
}
