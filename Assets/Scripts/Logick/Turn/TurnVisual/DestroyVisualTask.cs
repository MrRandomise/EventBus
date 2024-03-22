using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class DestroyVisualTask : TurnTask
    {
        private readonly EntityConfig _targetEntity;

        public DestroyVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            _targetEntity.IsDead = true;
            _targetEntity.View.GetHeroAudio().PlayDeath();
            _targetEntity.gameObject.SetActive(false);
            Finish();
        }
    }
}
