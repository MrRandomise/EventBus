using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class SwitchHeroVisualTask : TurnTask
    {
        private readonly EntityConfig _targetEntity;

        public SwitchHeroVisualTask (EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            _targetEntity.View.GetHeroAudio().PlayStatTurn();
            Finish();
        }
    }
}
