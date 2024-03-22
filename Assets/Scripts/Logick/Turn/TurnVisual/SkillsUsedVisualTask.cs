using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class SkillsUsedVisualTask : TurnTask
    {
        private readonly EntityConfig _targetEntity;

        public SkillsUsedVisualTask(EntityConfig targetEntity)
        {
            _targetEntity = targetEntity;
        }

        protected override void OnRun()
        {
            _targetEntity.View.GetHeroAudio().PlayAbility();
            Finish();
        }
    }
}
