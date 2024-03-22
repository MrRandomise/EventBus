using System.Collections.Generic;
using Logick.Events;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Logick.HeroesSkills
{
    public sealed class RandomHeal : BaseSkills
    {
        [ShowInInspector] private int _healAmount = 1;
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            if(currentEntity.Value.IsDead) return;
            
            var allyTeam = new List<EntityConfig>();
            allyTeam.AddRange(entityStorage.GetTeam(currentEntity.Value.Team));  
            allyTeam.Remove(currentEntity.Value);
            
            for(var i = 0; i < allyTeam.Count; i++)
            {
                if (allyTeam[i].IsDead) allyTeam.Remove(allyTeam[i]);
            }
            eventBus.RaiseEvent(new HealEvent(allyTeam[Random.Range(0,allyTeam.Count)], _healAmount));
        }
    }
}
