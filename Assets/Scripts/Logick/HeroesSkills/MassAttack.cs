using System.Collections.Generic;
using Logick.Events;

using Sirenix.OdinInspector;

namespace Logick.HeroesSkills
{
    public sealed class MassAttack : BaseSkills
    {
        [ShowInInspector] private int _damage = 1;
        public override void Run(EventBus eventBus, CurrentEntity currentEntity, AttackedEntity attackedEntity, EntityStorage entityStorage)
        {
            if(currentEntity.Value.IsDead) return;
            
            var enemyTeam = new List<EntityConfig>();
            
            enemyTeam.AddRange(entityStorage.GetTeam(!attackedEntity.Value.Team)); 
    
            for(var i = 0; i < enemyTeam.Count; i++)
            {
                if (!enemyTeam[i].IsDead)
                {
                    eventBus.RaiseEvent(new ExtraAttackEvent(attackedEntity.Value, enemyTeam[i], _damage));        
                }
            }
        }
    }
}
