using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class ActivateEntityVisualTask : TurnTask
    {
        private readonly EntityConfig _sourceEntity;

        public ActivateEntityVisualTask(EntityConfig sourceEntity)
        {
            _sourceEntity = sourceEntity;
        }

        protected override void OnRun()
        {
            _sourceEntity.View.SetActive(true);
            Finish();
        }
    }
}
