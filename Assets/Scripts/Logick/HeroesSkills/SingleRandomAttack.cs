using System.Collections.Generic;
using Logick.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Logick.HeroesSkills
{
    public sealed class SingleRandomAttack : BaseSkills
    {
        [ShowInInspector] private int _damage = 3;
        
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            if(currentEntity.Value.IsDead) return;
            
            var enemyTeam = new List<EntityConfig>();
            enemyTeam.AddRange(entityStorage.GetTeam(!currentEntity.Value.Team));

            for(var i = 0; i < enemyTeam.Count; i++)
            {
                if (enemyTeam[i].IsDead) enemyTeam.Remove(enemyTeam[i]);
            }
            eventBus.RaiseEvent(new ExtraAttackEvent(currentEntity.Value, enemyTeam[Random.Range(0,enemyTeam.Count)], _damage));
        }
    }
}
