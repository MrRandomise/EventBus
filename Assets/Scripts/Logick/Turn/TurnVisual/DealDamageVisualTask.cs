using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class DealDamageVisualTask : TurnTask
    {
        private readonly EntityConfig _targetEntity;

        public DealDamageVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            if (!_targetEntity.IsDead && _targetEntity.CurrentHealth < _targetEntity.Health / 3)
            {
                _targetEntity.View.GetHeroAudio().PlayLowHealth();
            }
            Finish();
        }
    }
}
