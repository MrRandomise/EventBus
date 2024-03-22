using UnityEngine;

namespace Logick.HeroesSkills
{
    public sealed class RandomTarget : BaseSkills
    {
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            var enemyTeam = entityStorage.GetActualTeam(!currentEntity.Value.Team);
            var randomResult = Random.Range(0, 99) + 100/enemyTeam.Count;
            if ( randomResult >= 50)
            {
                attackedEntity.Value = enemyTeam[Random.Range(0, enemyTeam.Count)];
                currentEntity.Value.SkipAttackTargeting = true;
            }
        }
    }
}
