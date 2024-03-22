using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class DeactivateEntityVisualTask : TurnTask
    {
        private readonly EntityConfig _sourceEntity;

        public DeactivateEntityVisualTask(EntityConfig sourceEntity)
        {
            _sourceEntity = sourceEntity;
        }

        protected override void OnRun()
        {
            _sourceEntity.View.SetActive(false);
            Finish();
        }
    }
}
