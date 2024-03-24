using UnityEngine;
using Logick.Turn;

namespace Logick.Visual.Tasks
{
    public sealed class DrawStatsTask : TurnTask
    {
        private readonly EntityConfig _entity;

        public DrawStatsTask(EntityConfig entity)
        {
            _entity = entity;
        }

        protected override void OnRun()
        {
            Debug.Log(($"{_entity.Damage}/{_entity.CurrentHealth}"));
            _entity.View.SetStats($"{_entity.Damage}/{_entity.CurrentHealth}");
            Finish();
        }
    }
}
